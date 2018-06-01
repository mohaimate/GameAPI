using GameAPI.Models;
using GameAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameAPI.Processors
{
    public class ProgressionProcessor
    {
        public static Progression getProgress(int AccountID)
        {
            //processing
            return ProgressionRepository.getProgress(AccountID);
            //validating
            //TODO
        }

        public static bool updateProgress(Progression progress)
        {
            //processing
            return ProgressionRepository.UpdateProgress(progress);
            //validating
            //TODO
        }
    }
}