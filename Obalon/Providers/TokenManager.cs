//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Web;
//using Obalon.Services;

////using SICAP.Infrastructure.Injection;
////using SICAP.Web.Domain.Services;
////using SICAP.Web.Model.Security;

//namespace Obalon.Security
//{

//    public interface ITokenManager
//    {
//        int TOKEN_EXPIRE_MIN { get; }

//        string BuildCacheKey(string ticket);
//        void AddTicket(string ticket, RefreshToken data);
//        RefreshToken GetRefreshToken(string ticket);
//        bool ExtendCurrentToken();
//        bool Remove(string ticket);
//    }

//    public class RefreshToken
//    {
//        public string Id { get; set; }
//        public string Subject { get; set; }
//        public string ClientId { get; set; }
//        public DateTimeOffset IssuedUtc { get; set; }
//        public DateTimeOffset ExpiresUtc { get; set; }
//        public string ProtectedTicket { get; set; }

//        public override string ToString()
//        {
//            return string.Format("refresh_token: {0} issued: {1} expires {2}", Id, IssuedUtc, ExpiresUtc);
//        }

//        public bool IsExpired
//        {
//            get { return ExpiresUtc < DateTimeOffset.UtcNow; }
//        }
//    }

//    /// <summary>
//    /// Manages all authentication tickets by providing access to AppFabric cache
//    /// </summary>
//    public class TokenManager : ITokenManager
//    {
//        public int TOKEN_EXPIRE_MIN { get { return 120; } }

//        readonly ICacheService cache;

//        public TokenManager()
//        {
//            cache = TheFactory.Resolve<ICacheService>();
//        }

//        public string BuildCacheKey(string ticket)
//        {
//            return CacheKey.AuthToken + "_" + ticket;
//        }

//        public void AddTicket(string ticket, RefreshToken data)
//        {
//            var key = BuildCacheKey(ticket);
//            cache.Put(key, data);
//        }

//        public RefreshToken GetRefreshToken(string ticket)
//        {
//            try
//            {
//                var key = BuildCacheKey(ticket);
//                return cache.Get(key) as RefreshToken;
//            }
//            catch { return null; }
//        }

//        public bool ExtendCurrentToken()
//        {
//            try
//            {
//                var cookie = HttpContext.Current.Request.Cookies["_RefreshToken"];
//                if (cookie == null || cookie.Value == null) return false;
//                var ticket = cookie.Value;

//                var key = BuildCacheKey(ticket);
//                var token = cache.Get(key) as RefreshToken;
//                if (token == null) return false;

//                token.ExpiresUtc = DateTime.UtcNow.AddMinutes(TOKEN_EXPIRE_MIN);
//                cache.Put(key, token);
//                return true;
//            }
//            catch { return false; }
//        }

//        public bool Remove(string ticket)
//        {
//            try
//            {
//                var key = BuildCacheKey(ticket);
//                return cache.Remove(key);
//            }
//            catch (Exception ex)
//            {
//                Debug.WriteLine("TOKEN MANAGER Remove() error" + ex);
//            }
//            return false;
//        }


//    }
//}