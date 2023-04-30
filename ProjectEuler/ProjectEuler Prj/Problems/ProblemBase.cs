using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class ProblemResult
    {
        public ProblemResult()
        {
            Result = null;
            ElapsedTime = 0;
        }

        public object Result { get; set; }
        public long ElapsedTime { get; set; }
    }


    public abstract class ProblemBase
    {
        private Stopwatch _sw = new Stopwatch();

        protected abstract object InternalExecute();

        public bool IsCancelled { get; set; }
        public bool IsCompleted { get; set; }
        public object Result { get; set; }
        public long ElapsedTime { get; set; }

        private void Run()
        {
            var cts = new CancellationTokenSource();
            var worker = Task.Factory.StartNew(() =>
            {

                _sw.Restart();
                {
                    Result = InternalExecute();
                }
                _sw.Stop();

                ElapsedTime = _sw.ElapsedMilliseconds;
            });

            int index = Task.WaitAny(new[] { worker }, TimeSpan.FromSeconds(2));


            Task cancellable = worker.ContinueWith(_ => { IsCancelled = true; }, cts.Token);


            index = Task.WaitAny(new[] { cancellable }, TimeSpan.FromSeconds(2));

            cts.Cancel();

            IsCompleted = true;
            IsCancelled = cancellable.Status == TaskStatus.Canceled;

            if (IsCancelled == true)
                Result = null;
        }

        public void Execute()
        {
            Run();

        }
    }
}
