using DAL;
using Data.Model.DBModel;
using Data.Model.ViewModel.Capital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class CapitalBLL: BaseBLL<PersonalWallet>
    {
        public override void SetDal()
        {
            _baseDal = new CapitalDAL();
        }

        /// <summary>
        /// 新增用户个人钱包
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public bool AddPersonalWallet(ReqPersonalWallet req)
        {
            if (req != null && !string.IsNullOrWhiteSpace(req.UserName))
            {
                new BaseBLL<PersonalWallet>().AddEntity(new PersonalWallet
                {
                    UserName = req.UserName,
                    Balance = 0,
                    CreateDate = DateTime.Now
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public bool Recharge(ReqConsumptiondetails req,string userid)
        {
            if (req != null)
            {
                new BaseBLL<Consumptiondetails>().AddEntity(new Consumptiondetails
                {
                  UserName= userid,
                  OrderNo=req.OrderNo,
                  BankNo=req.BankNo,
                  Amount=req.Amount,
                  Type=1,
                  CreateDate = DateTime.Now
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public bool CashAdvance(ReqConsumptiondetails req,string userid)
        {
            if (req != null)
            {
                new BaseBLL<Consumptiondetails>().AddEntity(new Consumptiondetails
                {
                    UserName = userid,
                    OrderNo = req.OrderNo,
                    BankNo = req.BankNo,
                    Amount = req.Amount,
                    Type = 2,
                    CreateDate = DateTime.Now
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Deduction(ReqConsumptiondetails req,string userid)
        {
            if (req != null)
            {
                new BaseBLL<Consumptiondetails>().AddEntity(new Consumptiondetails
                {
                    UserName = userid,
                    OrderNo = req.OrderNo,
                    BankNo = req.BankNo,
                    Amount = req.Amount,
                    Type = 3,
                    CreateDate = DateTime.Now
                });
                return true;
            }
            else
            {
                return false;
            }
        }
        

        /// <summary>
        /// 收入增加余额
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Amount"></param>
        public bool AddBalance(string UserName,decimal Amount)
        {
            var addBalance = new BaseBLL<PersonalWallet>().FirstOrDefault(x => x.UserName.Equals(UserName));
            if (addBalance != null)
            {
                addBalance.Balance = addBalance.Balance + Amount;
                new BaseBLL<PersonalWallet>().UpdateEntity(addBalance);
                return true;
            }
            return false;
        }
        public bool SubtractBalance(string UserName, decimal Amount)
        {
            var addBalance = new BaseBLL<PersonalWallet>().FirstOrDefault(x => x.UserName.Equals(UserName));
            if (addBalance != null)
            {
                addBalance.Balance = addBalance.Balance - Amount;
                new BaseBLL<PersonalWallet>().UpdateEntity(addBalance);
                return true;
            }
            return false;
        }
    }
}