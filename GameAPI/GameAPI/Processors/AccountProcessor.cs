using GameAPI.Models;
using GameAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameAPI.Processors
{
    public class AccountProcessor
    {
        public static bool RegisterAccount(Account account)
        {
            //processing
            return AccountRepository.AddAccount(account);
            //validating
            //TODO
        }

        public static int LoginAccount(Account account)
        {
            //processing
            return AccountRepository.Login(account);
            //validating
            //TODO
        }
    }
}