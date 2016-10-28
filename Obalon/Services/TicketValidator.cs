using System;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin;

namespace Obalon.Services
{
    public interface ITicketValidator
    {
        string GetUserIdFromTicket(string tiket);
    }


    public class TicketValidator : ITicketValidator
    {
        public string GetUserIdFromTicket(string tiket)
        {
            var secureDataFormat = new TicketDataFormat(new MachineKeyProtector());
            AuthenticationTicket ticketContent = secureDataFormat.Unprotect(tiket);

            return ticketContent.Identity.Name;
        }
    }

    /// <summary>
    /// Helper method to decrypt the OWIN ticket
    /// </summary>
    public class MachineKeyProtector : IDataProtector
    {
        private readonly string[] _purpose = {typeof(OAuthAuthorizationServerMiddleware).Namespace, "Access_Token", "v1" };

        public byte[] Protect(byte[] userData)
        {
            throw new NotImplementedException();
        }

        public byte[] Unprotect(byte[] protectedData)
        {
            return System.Web.Security.MachineKey.Unprotect(protectedData, _purpose);
        }
    }
    
}