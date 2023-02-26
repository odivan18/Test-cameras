using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Test_cameras
{
    class CancellationTokenHolder
    {
        CancellationTokenSource cancelTokenSource;

        public CancellationTokenHolder()
        {
            cancelTokenSource = new CancellationTokenSource();
        }

        public CancellationToken GetToken()
        {
            if (cancelTokenSource == null)
            {
                throw new Exception("Токена отмены не существует - его нельзя взять");
            }                

            return cancelTokenSource.Token;
        }

        public void Cancel()
        {
            if (cancelTokenSource == null)
            {
                throw new Exception("Токена отмены не существует - нельзя подать сигнал отмены");
            }                

            cancelTokenSource.Cancel();
        }

        public void TokenRefresh()
        {
            if (cancelTokenSource.Token.IsCancellationRequested || cancelTokenSource == null)
            {
                cancelTokenSource = new CancellationTokenSource();
            }
        }
    }
}
