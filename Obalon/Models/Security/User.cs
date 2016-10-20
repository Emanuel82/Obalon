using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obalon.Security
{
    public class User
    {
        public int? UserId { get; set; }
        public int UserSessionId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        //public List<Values.SysAppRight> Rights { get; set; }
        public bool? IsMaster { get; set; }
        public User()
        {
            //Rights = new List<Values.SysAppRight>();
        }

        /// <summary>
        /// User must have all rights requested
        /// </summary>
        //public bool HasAllRights(params Values.SysAppRight[] rights)
        //{
        //    return rights.All(x => Rights.Any(y => y == x));
        //}

        /// <summary>
        /// User must have alt least one right requested
        /// </summary>
        //public bool HasAnyRights(params Values.SysAppRight[] rights)
        //{
        //    return rights.Any(x => Rights.Any(y => y == x));
        //}

        //public bool HasRight(Values.SysAppRight right)
        //{
        //    return Rights.Any(x => x == right);
        //}

        //public bool UserIs(params Values.SysEntityType[] entityType)
        //{
        //    return Entity != null && entityType.Any(e => Entity.EntityType == e);
        //}
    }
}