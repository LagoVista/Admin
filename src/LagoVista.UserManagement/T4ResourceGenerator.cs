using System.Globalization;
using System.Reflection;

//Resources:UserManagementResources:Admin_Contact
namespace LagoVista.UserManagement.Resources
{
	public class UserManagementResources
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LagoVista.UserManagement.Resources.UserManagementResources", typeof(UserManagementResources).GetTypeInfo().Assembly);
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
			var culture = CultureInfo.CurrentCulture;;
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
		
		public static string Admin_Contact { get { return GetResourceString("Admin_Contact"); } }
//Resources:UserManagementResources:AppUser_ConfirmPassword

		public static string AppUser_ConfirmPassword { get { return GetResourceString("AppUser_ConfirmPassword"); } }
//Resources:UserManagementResources:AppUser_Email

		public static string AppUser_Email { get { return GetResourceString("AppUser_Email"); } }
//Resources:UserManagementResources:AppUser_FirstName

		public static string AppUser_FirstName { get { return GetResourceString("AppUser_FirstName"); } }
//Resources:UserManagementResources:AppUser_LastName

		public static string AppUser_LastName { get { return GetResourceString("AppUser_LastName"); } }
//Resources:UserManagementResources:AppUser_NewPassword

		public static string AppUser_NewPassword { get { return GetResourceString("AppUser_NewPassword"); } }
//Resources:UserManagementResources:AppUser_OldPassword

		public static string AppUser_OldPassword { get { return GetResourceString("AppUser_OldPassword"); } }
//Resources:UserManagementResources:AppUser_Password

		public static string AppUser_Password { get { return GetResourceString("AppUser_Password"); } }
//Resources:UserManagementResources:AppUser_PasswordConfirmPasswordMatch

		public static string AppUser_PasswordConfirmPasswordMatch { get { return GetResourceString("AppUser_PasswordConfirmPasswordMatch"); } }
//Resources:UserManagementResources:AppUser_PhoneNumber

		public static string AppUser_PhoneNumber { get { return GetResourceString("AppUser_PhoneNumber"); } }
//Resources:UserManagementResources:AppUser_PhoneVerificationCode

		public static string AppUser_PhoneVerificationCode { get { return GetResourceString("AppUser_PhoneVerificationCode"); } }
//Resources:UserManagementResources:AppUser_RememberMe

		public static string AppUser_RememberMe { get { return GetResourceString("AppUser_RememberMe"); } }
//Resources:UserManagementResources:AppUser_RememberMe_InThisBrowser

		public static string AppUser_RememberMe_InThisBrowser { get { return GetResourceString("AppUser_RememberMe_InThisBrowser"); } }
//Resources:UserManagementResources:Billing_Contact

		public static string Billing_Contact { get { return GetResourceString("Billing_Contact"); } }
//Resources:UserManagementResources:Common_CreatedBy

		public static string Common_CreatedBy { get { return GetResourceString("Common_CreatedBy"); } }
//Resources:UserManagementResources:Common_CreationDate

		public static string Common_CreationDate { get { return GetResourceString("Common_CreationDate"); } }
//Resources:UserManagementResources:Common_Description

		public static string Common_Description { get { return GetResourceString("Common_Description"); } }
//Resources:UserManagementResources:Common_EmailAddress

		public static string Common_EmailAddress { get { return GetResourceString("Common_EmailAddress"); } }
//Resources:UserManagementResources:Common_Id

		public static string Common_Id { get { return GetResourceString("Common_Id"); } }
//Resources:UserManagementResources:Common_LastUpdatedBy

		public static string Common_LastUpdatedBy { get { return GetResourceString("Common_LastUpdatedBy"); } }
//Resources:UserManagementResources:Common_LastUpdatedDate

		public static string Common_LastUpdatedDate { get { return GetResourceString("Common_LastUpdatedDate"); } }
//Resources:UserManagementResources:Common_Namespce

		public static string Common_Namespce { get { return GetResourceString("Common_Namespce"); } }
//Resources:UserManagementResources:Common_Notes

		public static string Common_Notes { get { return GetResourceString("Common_Notes"); } }
//Resources:UserManagementResources:Common_PhoneNumber

		public static string Common_PhoneNumber { get { return GetResourceString("Common_PhoneNumber"); } }
//Resources:UserManagementResources:Common_Role

		public static string Common_Role { get { return GetResourceString("Common_Role"); } }
//Resources:UserManagementResources:Common_Status

		public static string Common_Status { get { return GetResourceString("Common_Status"); } }
//Resources:UserManagementResources:InuteUser_Status_Declined

		public static string InuteUser_Status_Declined { get { return GetResourceString("InuteUser_Status_Declined"); } }
//Resources:UserManagementResources:Invite_Greeting_Subject

		public static string Invite_Greeting_Subject { get { return GetResourceString("Invite_Greeting_Subject"); } }
//Resources:UserManagementResources:InviteUser_AlreadyPartOfOrg

		public static string InviteUser_AlreadyPartOfOrg { get { return GetResourceString("InviteUser_AlreadyPartOfOrg"); } }
//Resources:UserManagementResources:InviteUser_ClickHere

		public static string InviteUser_ClickHere { get { return GetResourceString("InviteUser_ClickHere"); } }
//Resources:UserManagementResources:InviteUser_Greeting_Label

		public static string InviteUser_Greeting_Label { get { return GetResourceString("InviteUser_Greeting_Label"); } }
//Resources:UserManagementResources:InviteUser_Greeting_Message


		///<summary>
		///WIll replace [USERS_FULL_NAME] with the first/last name of current user, [ORG_NAME] as the name of the organization.
		///</summary>
		public static string InviteUser_Greeting_Message { get { return GetResourceString("InviteUser_Greeting_Message"); } }
//Resources:UserManagementResources:InviteUser_InvitedById


		///<summary>
		///No need to translate
		///</summary>
		public static string InviteUser_InvitedById { get { return GetResourceString("InviteUser_InvitedById"); } }
//Resources:UserManagementResources:InviteUser_InvitedByName

		public static string InviteUser_InvitedByName { get { return GetResourceString("InviteUser_InvitedByName"); } }
//Resources:UserManagementResources:InviteUser_Name

		public static string InviteUser_Name { get { return GetResourceString("InviteUser_Name"); } }
//Resources:UserManagementResources:InviteUser_Status

		public static string InviteUser_Status { get { return GetResourceString("InviteUser_Status"); } }
//Resources:UserManagementResources:InviteUser_Status_Accepted

		public static string InviteUser_Status_Accepted { get { return GetResourceString("InviteUser_Status_Accepted"); } }
//Resources:UserManagementResources:InviteUser_Status_Queued

		public static string InviteUser_Status_Queued { get { return GetResourceString("InviteUser_Status_Queued"); } }
//Resources:UserManagementResources:Location_Address1

		public static string Location_Address1 { get { return GetResourceString("Location_Address1"); } }
//Resources:UserManagementResources:Location_Address2

		public static string Location_Address2 { get { return GetResourceString("Location_Address2"); } }
//Resources:UserManagementResources:Location_Admin_Contact

		public static string Location_Admin_Contact { get { return GetResourceString("Location_Admin_Contact"); } }
//Resources:UserManagementResources:Location_City

		public static string Location_City { get { return GetResourceString("Location_City"); } }
//Resources:UserManagementResources:Location_Country

		public static string Location_Country { get { return GetResourceString("Location_Country"); } }
//Resources:UserManagementResources:Location_GeoLocation

		public static string Location_GeoLocation { get { return GetResourceString("Location_GeoLocation"); } }
//Resources:UserManagementResources:Location_LocationName

		public static string Location_LocationName { get { return GetResourceString("Location_LocationName"); } }
//Resources:UserManagementResources:Location_PostalCode

		public static string Location_PostalCode { get { return GetResourceString("Location_PostalCode"); } }
//Resources:UserManagementResources:Location_State

		public static string Location_State { get { return GetResourceString("Location_State"); } }
//Resources:UserManagementResources:LocationNamespace_Help

		public static string LocationNamespace_Help { get { return GetResourceString("LocationNamespace_Help"); } }
//Resources:UserManagementResources:Organization

		public static string Organization { get { return GetResourceString("Organization"); } }
//Resources:UserManagementResources:Organization_CantCreate

		public static string Organization_CantCreate { get { return GetResourceString("Organization_CantCreate"); } }
//Resources:UserManagementResources:Organization_Location

		public static string Organization_Location { get { return GetResourceString("Organization_Location"); } }
//Resources:UserManagementResources:Organization_Locations

		public static string Organization_Locations { get { return GetResourceString("Organization_Locations"); } }
//Resources:UserManagementResources:Organization_Name

		public static string Organization_Name { get { return GetResourceString("Organization_Name"); } }
//Resources:UserManagementResources:Organization_NamespaceInUse

		public static string Organization_NamespaceInUse { get { return GetResourceString("Organization_NamespaceInUse"); } }
//Resources:UserManagementResources:Organization_Primary_Location

		public static string Organization_Primary_Location { get { return GetResourceString("Organization_Primary_Location"); } }
//Resources:UserManagementResources:Organization_Status_Active

		public static string Organization_Status_Active { get { return GetResourceString("Organization_Status_Active"); } }
//Resources:UserManagementResources:Organization_Status_Active_BehindPayments

		public static string Organization_Status_Active_BehindPayments { get { return GetResourceString("Organization_Status_Active_BehindPayments"); } }
//Resources:UserManagementResources:Organization_Status_Archived

		public static string Organization_Status_Archived { get { return GetResourceString("Organization_Status_Archived"); } }
//Resources:UserManagementResources:Organization_WebSite

		public static string Organization_WebSite { get { return GetResourceString("Organization_WebSite"); } }
//Resources:UserManagementResources:OrganizationAccount_CouldntAdd

		public static string OrganizationAccount_CouldntAdd { get { return GetResourceString("OrganizationAccount_CouldntAdd"); } }
//Resources:UserManagementResources:OrganizationAccount_UserExists

		public static string OrganizationAccount_UserExists { get { return GetResourceString("OrganizationAccount_UserExists"); } }
//Resources:UserManagementResources:OrganizationLocation_NamespaceInUse

		public static string OrganizationLocation_NamespaceInUse { get { return GetResourceString("OrganizationLocation_NamespaceInUse"); } }
//Resources:UserManagementResources:OrganizationNamespace_Help

		public static string OrganizationNamespace_Help { get { return GetResourceString("OrganizationNamespace_Help"); } }
//Resources:UserManagementResources:Technical_Contact

		public static string Technical_Contact { get { return GetResourceString("Technical_Contact"); } }
//Resources:UserManagementResources:User

		public static string User { get { return GetResourceString("User"); } }
//Resources:UserManagementResources:VerifyUser_BrowserRemembered

		public static string VerifyUser_BrowserRemembered { get { return GetResourceString("VerifyUser_BrowserRemembered"); } }
//Resources:UserManagementResources:VerifyUser_EmailConfirmed

		public static string VerifyUser_EmailConfirmed { get { return GetResourceString("VerifyUser_EmailConfirmed"); } }
//Resources:UserManagementResources:VerifyUser_ExistingPhoneNumber

		public static string VerifyUser_ExistingPhoneNumber { get { return GetResourceString("VerifyUser_ExistingPhoneNumber"); } }
//Resources:UserManagementResources:VerifyUser_PhoneConfirmed

		public static string VerifyUser_PhoneConfirmed { get { return GetResourceString("VerifyUser_PhoneConfirmed"); } }

		public static class Names
		{
			public const string Admin_Contact = "Admin_Contact";
			public const string AppUser_ConfirmPassword = "AppUser_ConfirmPassword";
			public const string AppUser_Email = "AppUser_Email";
			public const string AppUser_FirstName = "AppUser_FirstName";
			public const string AppUser_LastName = "AppUser_LastName";
			public const string AppUser_NewPassword = "AppUser_NewPassword";
			public const string AppUser_OldPassword = "AppUser_OldPassword";
			public const string AppUser_Password = "AppUser_Password";
			public const string AppUser_PasswordConfirmPasswordMatch = "AppUser_PasswordConfirmPasswordMatch";
			public const string AppUser_PhoneNumber = "AppUser_PhoneNumber";
			public const string AppUser_PhoneVerificationCode = "AppUser_PhoneVerificationCode";
			public const string AppUser_RememberMe = "AppUser_RememberMe";
			public const string AppUser_RememberMe_InThisBrowser = "AppUser_RememberMe_InThisBrowser";
			public const string Billing_Contact = "Billing_Contact";
			public const string Common_CreatedBy = "Common_CreatedBy";
			public const string Common_CreationDate = "Common_CreationDate";
			public const string Common_Description = "Common_Description";
			public const string Common_EmailAddress = "Common_EmailAddress";
			public const string Common_Id = "Common_Id";
			public const string Common_LastUpdatedBy = "Common_LastUpdatedBy";
			public const string Common_LastUpdatedDate = "Common_LastUpdatedDate";
			public const string Common_Namespce = "Common_Namespce";
			public const string Common_Notes = "Common_Notes";
			public const string Common_PhoneNumber = "Common_PhoneNumber";
			public const string Common_Role = "Common_Role";
			public const string Common_Status = "Common_Status";
			public const string InuteUser_Status_Declined = "InuteUser_Status_Declined";
			public const string Invite_Greeting_Subject = "Invite_Greeting_Subject";
			public const string InviteUser_AlreadyPartOfOrg = "InviteUser_AlreadyPartOfOrg";
			public const string InviteUser_ClickHere = "InviteUser_ClickHere";
			public const string InviteUser_Greeting_Label = "InviteUser_Greeting_Label";
			public const string InviteUser_Greeting_Message = "InviteUser_Greeting_Message";
			public const string InviteUser_InvitedById = "InviteUser_InvitedById";
			public const string InviteUser_InvitedByName = "InviteUser_InvitedByName";
			public const string InviteUser_Name = "InviteUser_Name";
			public const string InviteUser_Status = "InviteUser_Status";
			public const string InviteUser_Status_Accepted = "InviteUser_Status_Accepted";
			public const string InviteUser_Status_Queued = "InviteUser_Status_Queued";
			public const string Location_Address1 = "Location_Address1";
			public const string Location_Address2 = "Location_Address2";
			public const string Location_Admin_Contact = "Location_Admin_Contact";
			public const string Location_City = "Location_City";
			public const string Location_Country = "Location_Country";
			public const string Location_GeoLocation = "Location_GeoLocation";
			public const string Location_LocationName = "Location_LocationName";
			public const string Location_PostalCode = "Location_PostalCode";
			public const string Location_State = "Location_State";
			public const string LocationNamespace_Help = "LocationNamespace_Help";
			public const string Organization = "Organization";
			public const string Organization_CantCreate = "Organization_CantCreate";
			public const string Organization_Location = "Organization_Location";
			public const string Organization_Locations = "Organization_Locations";
			public const string Organization_Name = "Organization_Name";
			public const string Organization_NamespaceInUse = "Organization_NamespaceInUse";
			public const string Organization_Primary_Location = "Organization_Primary_Location";
			public const string Organization_Status_Active = "Organization_Status_Active";
			public const string Organization_Status_Active_BehindPayments = "Organization_Status_Active_BehindPayments";
			public const string Organization_Status_Archived = "Organization_Status_Archived";
			public const string Organization_WebSite = "Organization_WebSite";
			public const string OrganizationAccount_CouldntAdd = "OrganizationAccount_CouldntAdd";
			public const string OrganizationAccount_UserExists = "OrganizationAccount_UserExists";
			public const string OrganizationLocation_NamespaceInUse = "OrganizationLocation_NamespaceInUse";
			public const string OrganizationNamespace_Help = "OrganizationNamespace_Help";
			public const string Technical_Contact = "Technical_Contact";
			public const string User = "User";
			public const string VerifyUser_BrowserRemembered = "VerifyUser_BrowserRemembered";
			public const string VerifyUser_EmailConfirmed = "VerifyUser_EmailConfirmed";
			public const string VerifyUser_ExistingPhoneNumber = "VerifyUser_ExistingPhoneNumber";
			public const string VerifyUser_PhoneConfirmed = "VerifyUser_PhoneConfirmed";
		}
	}
}
