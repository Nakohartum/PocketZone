using System;
using System.Collections.Generic;
using _Root.Code.Interfaces;

namespace _Root.Code
{
    public class UpdateManager : IExecutable, IDisposable
    {
        private List<IExecutable> _executables;
        private List<IDisposable> _disposables;
        private static UpdateManager _instance;

        public static UpdateManager Instance
        {
            get
            {
                return _instance ??= new UpdateManager();
            }
        }

        private UpdateManager()
        {
            _executables = new List<IExecutable>();
            _disposables = new List<IDisposable>();
        }
        
        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executables.Count; i++)
            {
                _executables[i].Execute(deltaTime);
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < _disposables.Count; i++)
            {
                _disposables[i].Dispose();
            }
            _disposables.Clear();
        }

        public void AddExecutable(IExecutable executable)
        {
            _executables.Add(executable);
        }

        public void RemoveExecutable(IExecutable executable)
        {
            _executables.Remove(executable);
        }

        public void AddDisposable(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }

        public void RemoveDisposables(IDisposable disposable)
        {
            _disposables.Remove(disposable);
        }
    }
}