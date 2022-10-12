using System;
using System.Collections.Generic;

namespace Model.DailyReward.InformationProvider
{
    public interface IRewardInformatioProvider
    {
        DailyRewardInformation GetInfo();
    }
}
