using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StatementModel
{
    public static class LedgerAnalyzer
    {

        public static List<int> CourierAcquisitionTotal 
        {
            get 
            {
                var list = new List<int>();
                list.AddRange(NewCourierAcquisition);
                list.AddRange(CourierRectivation);
                list.AddRange(CourierReferral);
                return list;    
            }
        }
        public static List<int> NewCourierAcquisition 
        {
            get 
            {
                return new List<int>() {
                    107 /* جشنواره شروع به کار */
                };
            }
        }

        public static List<int> CourierRectivation 
        {
            get 
            {
                return new List<int>() {
                    214/* تشویقی شروع مجدد*/,
                    104/* تشویقی بازگشت به کار*/
                };
            }
        }
        public static List<int> CourierReferral 
        {
            get 
            {
                return new List<int>() {
                    29/* ریفرال*/
                };
            }
        }

        public static List<int> CourierDisribution 
        {
            get 
            {
                return new List<int>() {
                    219/* تشویقی - تم*/
                };
            }
        }
        
        public static List<int> TripInstanceIncentiveTotal 
        {
            get 
            {
                var list = new List<int>();
                list.AddRange(TripFarAssign);
                list.AddRange(Revoke);
                list.AddRange(HurryTrip);
                return list;
            }
        }

        public static List<int> TripFarAssign 
        {
            get 
            {
                return new List<int>() {
                    128 /* تک سرویس*/ ,
                    68  /* مبدا دور*/,
                    129 /* جابه‌چایی منطقه*/
                };
            }
        }

        public static List<int> Revoke 
        {
            get 
            {
                return new List<int>() {
                    10000 // dummy                     
                };
            }
        }

        public static List<int> HurryTrip 
        {
            get 
            {
                return new List<int>() {
                    130 /* سفر طلایی */
                };
            }
        }
      
    }
    
}