using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_VPNApp.Helpers
{
    public class VPNConnectionResult
    {
        /// <summary>
        /// Указывает на состояние подключения, true - подключение успешно, false - ошибка во время подключения
        /// </summary>
        public bool isConnected { get; set; }
        /// <summary>
        /// Сообщение об ошибке произошедшей во время подключения
        /// </summary>
        public string errorMessage { get; set; }
    }
}
