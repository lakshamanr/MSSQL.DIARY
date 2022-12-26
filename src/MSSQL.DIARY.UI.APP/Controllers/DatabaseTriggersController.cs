﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MSSQL.DIARY.COMN.Models;
using MSSQL.DIARY.SRV;
using Microsoft.AspNetCore.Authorization;
using MSSQL.DIARY.UI.APP.Data;
using Microsoft.AspNetCore.Identity;
using MSSQL.DIARY.UI.APP.Models;
using Microsoft.AspNetCore.Http;

namespace MSSQL.DIARY.UI.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DatabaseTriggersController : ApplicationBaseController
    {
        

        public DatabaseTriggersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) : base(context, userManager, httpContextAccessor)
        {
            SrvDatabaseTrigger = new SrvMssql();
        }

        private SrvMssql SrvDatabaseTrigger { get; }

        [HttpGet("[action]")]
        public List<PropertyInfo> GetAllDatabaseTrigger(string istrdbName)
        {
            return SrvDatabaseTrigger.GetTriggers(istrdbName);
        }

        [HttpGet("[action]")]
        public TriggerInfo GetTriggerInfosByName(string istrdbName, string istrTriggerName)
        {
            return SrvDatabaseTrigger.GetTrigger(istrdbName, istrTriggerName).FirstOrDefault();
        }

        [HttpGet("[action]")]
        public void CreateOrUpdateTriggerDescription(string istrdbName, string astrDescription_Value,
            string astrTrigger_Name)
        {
            SrvDatabaseTrigger.CreateOrUpdateTriggerDescription(istrdbName, astrDescription_Value, astrTrigger_Name);
        }
    }
}