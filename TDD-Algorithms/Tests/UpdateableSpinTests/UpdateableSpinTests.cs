using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDD_Algorithms.Tests.UpdateableSpinTests
{
    [TestFixture]
    class UpdateableSpinTests
    {
        [Test]
        public void Wait_NoPulse_ReturnsFalse()
        {
            UpdateableSpin spin = new UpdateableSpin();
            bool wasPulsed = spin.Wait(TimeSpan.FromMilliseconds(10));
            Assert.IsFalse(wasPulsed);
        }

        [Test]
        public void Wait_Pulse_ReturnsTrue()
        {
            UpdateableSpin spin = new UpdateableSpin();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                spin.Set();
            });
            bool wasPulsed = spin.Wait(TimeSpan.FromSeconds(10));
            Assert.IsTrue(wasPulsed);
        }

        [Test]
        public void Wait50Millisec_ActuallyWaitingFor50Millisec()
        {
            var spin = new UpdateableSpin();

            Stopwatch watcher = new Stopwatch();
            watcher.Start();

            spin.Wait(TimeSpan.FromMilliseconds(50));

            watcher.Stop();

            TimeSpan actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
            TimeSpan leftEpsilon = TimeSpan.FromMilliseconds(50 - (50 * 0.1));
            TimeSpan rightEpsilon = TimeSpan.FromMilliseconds(50 + (50 * 0.1));

            Assert.IsTrue(actual > leftEpsilon && actual < rightEpsilon);
        }

        [Test]
        public void Wait50Millisec_UpdateAfter300Millisec_TotalWaitingIsApprox800Millisec()
        {
            var spin = new UpdateableSpin();
            
            var watcher = new Stopwatch();
            watcher.Start();

            const int timeout = 500;
            const int spanBeforeUpdate = 300;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(spanBeforeUpdate);
                spin.UpdateTimeout();
            });

            spin.Wait(TimeSpan.FromMilliseconds(timeout));

            watcher.Stop();

            TimeSpan actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
            const int expected = timeout + spanBeforeUpdate;

            TimeSpan left = TimeSpan.FromMilliseconds(expected - (expected * 0.1));
            TimeSpan right = TimeSpan.FromMilliseconds(expected + (expected * 0.1));

            Assert.IsTrue(actual > left && actual < right);

        }

    }

    public class UpdateableSpin
    {
        private readonly object lockObj = new object();
        private bool shouldWait = true;
        private long executionStartingTime;

        public bool Wait(TimeSpan timeout, int spinDuration = 0)
        {
            UpdateTimeout();
            while (true)
            {
                lock (lockObj)
                {
                    if (!shouldWait)
                        return true;
                    if (DateTime.UtcNow.Ticks - executionStartingTime > timeout.Ticks)
                        return false;
                }

                Thread.Sleep(spinDuration);
            }
        }

        public void Set()
        {
            lock (lockObj)
            {
                shouldWait = false;
            }
        }

        public void UpdateTimeout()
        {
            lock (lockObj)
            {
                executionStartingTime = DateTime.UtcNow.Ticks;
            }
        }
    }
}
