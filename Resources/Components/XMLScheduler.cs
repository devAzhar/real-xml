using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Scheduling;

namespace DotNetNuke.Modules.MaggieDixon.Components
{
    public class XMLScheduler : SchedulerClient
    {
        public XMLScheduler(ScheduleHistoryItem oItem)
            : base()
        {
            this.ScheduleHistoryItem = oItem;
           
        }
        public override void DoWork()
        {
            try
            { //Perform required items for logging 
                this.Progressing();
                //Your code goes here
                var portalID = Convert.ToInt32(WebConfigurationManager.AppSettings["MaggieDixonListingPortalID"]);
                XMLUtility.ReadRentXML(portalID, true);
              //  XMLUtility.ReadBuyXML(portalID, true);
               // XMLUtility.ReadBuyMyDXML(portalID, true);
                XMLUtility.ReadBuyREAXML(portalID, true);
                
                //To log note 
                this.ScheduleHistoryItem.AddLogNote("XML Update Succesfully.");

                //Show success 
                this.ScheduleHistoryItem.Succeeded = true;
            }
            catch (Exception ex)
            {
                this.ScheduleHistoryItem.Succeeded = false; 
                //InsertLogNote("Exception= " + ex.ToString());
                this.ScheduleHistoryItem.AddLogNote(ex.ToString());
                this.Errored(ref ex); 
                Services.Exceptions.Exceptions.LogException(ex);
            }
        } 
    }
        
}