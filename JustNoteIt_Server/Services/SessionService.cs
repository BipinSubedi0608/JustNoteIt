using JustNoteIt_Server.Interfaces;
using Microsoft.AspNetCore.Http;
using System;

namespace JustNoteIt_Server.Services
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? GetUserIdFromSession()
        {
            string? userId = _httpContextAccessor?.HttpContext?.Session.GetString("UserId");
            return userId == null ? null : Guid.Parse(userId);
        }

        public void SetUserIdToSession(Guid userId)
        {
            _httpContextAccessor?.HttpContext?.Session.SetString("UserId", userId.ToString());
        }

        public void RemoveUserIdFromSession()
        {
            _httpContextAccessor?.HttpContext?.Session.Remove("UserId");
        }
    }
}
