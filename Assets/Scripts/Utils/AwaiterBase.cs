//using System;

//namespace Utils
//{
//    public abstract AwaiterBase<TAwaited> : IAwaiter<TAwaited>
//    {
//        private Action _continuation;
//        private bool _isCompleted;
//        private TAwaited _result;
//        public bool IsCompleted => _isCompleted;
//        public TAwaited GetResult() => _result;

//    public void OnCompleted(Action continuation)
//    {
//        if (_isCompleted)
//        {
//            continuation?.Invoke();
//        }
//        else
//        {
//            _continuation = continuation;
//        }
//    }
//    protected void onWaitFinish(TAwaited result)
//    {
//        _result = result;
//        _isCompleted = true;
//        _continuation?.Invoke();
//    }
//}
//}
