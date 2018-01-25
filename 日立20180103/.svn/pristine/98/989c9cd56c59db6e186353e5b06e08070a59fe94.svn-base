using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code030
{
    public class Emun_ComInformation
    {
        Emun_ComInformation(_Emun_ComInformation _emun) {
            ChooseComInformation(_emun);
        }

        public enum _Emun_ComInformation
        {
            szrl082=0,
            szrl083=1
        }
        private string ChooseComInformation(_Emun_ComInformation _enum)
        {
            string item = string.Empty;
            switch (_enum)
            {
                case _Emun_ComInformation.szrl082:
                    item = "szrl082";
                    break;
                case _Emun_ComInformation.szrl083:
                    item = "szrl083";
                    break;
                default:
                    item = string.Empty;
                    break;

            }
            return item;
        }




    }

}
