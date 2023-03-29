//using Abstractions.Commands.CommandExecutors;

//namespace Utils
//{
//    public class StopAwaiter : AwaiterBase<AsyncExtensions.Void>
//    {
//        private readonly StopCommandExecutor _unitMovementStop;
//        public StopAwaiter(StopCommandExecutor unitMovementStop)
//        {
//            _unitMovementStop = unitMovementStop;
//            _unitMovementStop.OnStop += onStop;
//        }
//        private void onStop()
//        {
//            _unitMovementStop.OnStop -= onStop;
//            onWaitFinish(new AsyncExtensions.Void());
//        }
//    }
//}
