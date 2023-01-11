using HasB4bBase.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.EntityAccess
{
    public class Campaign : BaseModels
    {
        public int Id { get; set; }
        public int Discount { get; set; }
        public double CampaignPrice { get; set; }
        public string CampaignCoupon { get; set; }
        public string CampaignAnnouncement{ get; set; }

        public Campaign()
        {
            this.Id = 0;
            this.Discount = 0;
            this.CampaignPrice = 0;
            this.CampaignCoupon = "None";
            this.CampaignAnnouncement = "None";
        }

    }
}