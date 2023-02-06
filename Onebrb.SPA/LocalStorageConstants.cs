namespace Onebrb.SPA
{
    public class LocalStorageConstants
    {
        // For currently logged in user
        public const string OnebrbCurrentUser = "Onebrb_CurrentUser";

        public const string OnebrbCurrentUserLoggedIn = $"{OnebrbCurrentUser}_IsLoggedIn";
        public const string OnebrbCurrentUserProfile = $"{OnebrbCurrentUser}_UserProfile";
        public const string OnebrbCurrentUserComments = $"{OnebrbCurrentUser}_Comments";
        public const string OnebrbCurrentUserCommented = $"{OnebrbCurrentUser}_Commented";

        // Some user
        public const string OnebrbUser = "Onebrb_UserId";
        public const string OnebrbUserComments = $"{OnebrbUser}_Comments";


        // General
        public const string OnebrbGeneral = "Onebrb_General";

        public const string Occupations = $"{OnebrbGeneral}_Occupations";
        public const string Countries = $"{OnebrbGeneral}_Countries";
    }
}
