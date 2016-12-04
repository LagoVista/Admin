using System.Threading;

//LocalizationResources:IdentityResources:Login_Email
namespace LagoVista.Web.Identity.Resources.LocalizationResources
{
	public class IdentityResources
	{
        private static global::System.Resources.ResourceManager resourceMan;
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager 
		{
            get 
			{
                if (object.ReferenceEquals(resourceMan, null)) 
				{
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LagoVista.Web.Identity.LocalizationResources.IdentityResources", typeof(IdentityResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static string GetResourceString(string key, params string[] tokens)
		{
			var culture = Thread.CurrentThread.CurrentCulture;
            var str = ResourceManager.GetString(key, culture);

			for(int i = 0; i < tokens.Length; i += 2)
				str = str.Replace(tokens[i], tokens[i+1]);
										
            return str;
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
		/*
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static HtmlString GetResourceHtmlString(string key, params string[] tokens)
		{
			var str = GetResourceString(key, tokens);
							
			if(str.StartsWith("HTML:"))
				str = str.Substring(5);

			return new HtmlString(str);
        }*/
		
		public static string Login_Email { get { return GetResourceString("Login_Email"); } }
//LocalizationResources:IdentityResources:Login_ForgotPassword

		public static string Login_ForgotPassword { get { return GetResourceString("Login_ForgotPassword"); } }
//LocalizationResources:IdentityResources:Login_Password

		public static string Login_Password { get { return GetResourceString("Login_Password"); } }
//LocalizationResources:IdentityResources:Login_RememberMe

		public static string Login_RememberMe { get { return GetResourceString("Login_RememberMe"); } }
//LocalizationResources:IdentityResources:Login_RememberMe_Help

		public static string Login_RememberMe_Help { get { return GetResourceString("Login_RememberMe_Help"); } }
//LocalizationResources:IdentityResources:Login_UserName

		public static string Login_UserName { get { return GetResourceString("Login_UserName"); } }

		public static class Names
		{
			public const string Login_Email = "Login_Email";
			public const string Login_ForgotPassword = "Login_ForgotPassword";
			public const string Login_Password = "Login_Password";
			public const string Login_RememberMe = "Login_RememberMe";
			public const string Login_RememberMe_Help = "Login_RememberMe_Help";
			public const string Login_UserName = "Login_UserName";
		}
	}
}
