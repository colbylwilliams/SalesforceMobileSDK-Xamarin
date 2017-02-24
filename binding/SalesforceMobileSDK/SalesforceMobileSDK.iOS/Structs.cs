using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace SalesforceMobileSDK.iOS
{
	[Native]
	public enum SFASchemaType : long
	{
		Interaction = 0,
		PageView,
		Perf,
		Error
	}

	[Native]
	public enum SFAEventType : long
	{
		User = 0,
		System,
		Error,
		Crud
	}

	[Native]
	public enum SFAErrorType : long
	{
		Info = 0,
		Warn,
		Error
	}

	[Native]
	public enum SFSDKReachabilityNetworkStatus : long
	{
		NotReachable = 0,
		ReachableViaWiFi,
		ReachableViaWWAN
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CSFPrimitivePointer
	{
		public unsafe int intPtr;

		public unsafe uint unsignedIntPtr;

		public unsafe bool boolPtr;

		public unsafe nint integerPtr;

		public unsafe nuint unsignedIntegerPtr;

		public unsafe float floatPtr;

		public unsafe double doublePtr;

		public unsafe sbyte charPtr;

		public unsafe byte unsignedCharPtr;

		public unsafe short shortPtr;

		public unsafe ushort unsignedShortPtr;

		public unsafe nint longPtr;

		public unsafe nuint unsignedLongPtr;

		public unsafe long longLongPtr;

		public unsafe ulong unsignedLongLongPtr;
	}

	[Native]
	public enum CSFActionExecutionCapType : ulong
	{
		Unlimited = 0,
		OncePerSession
	}

	[Native]
	public enum CSFInteractionContext : long
	{
		User = 0,
		Programmatic
	}

	[Native]
	public enum CSFChatterCommunityMode : long
	{
		Optional = 0,
		Required,
		Disallowed
	}

	[Native]
	public enum CSFNetworkErrorCode : long
	{
		APIError = 1000,
		InternalError,
		CancelledError,
		NetworkNotReadyError,
		HTTPResponseError,
		URLResponseInvalidError,
		URLCredentialsError,
		InvalidActionParameterError,
		JSONInvalidError,
		CacheError
	}

	[Native]
	public enum CSFValidationErrorCode : long
	{
		DataTypeError = 1100,
		RangeError
	}

	[Native]
	public enum CSFParameterStyle : ulong
	{
		None = 0,
		QueryString,
		URLEncoded,
		Multipart
	}

	[Native]
	public enum CSFForceLayoutComponentType : long
	{
		Unknown,
		EmptySpace,
		Field,
		SControl,
		Separator
	}

	[Native]
	public enum CSFForceQuickActionType : long
	{
		Unknown,
		Create,
		Visualforce,
		Post,
		Feed,
		Poll,
		File,
		Thanks
	}

	[Native]
	public enum CSFForceNotificationFrequency : long
	{
		Unknown,
		EachPost,
		DailyDigest,
		WeeklyDigest,
		Never
	}

	[Native]
	public enum CSFForcePortalRoleType : long
	{
		Unknown,
		Executive,
		Manager,
		User,
		PersonAccount
	}

	[Native]
	public enum CSFForcePortalType : long
	{
		Unknown,
		None,
		CustomerPortal,
		Partner
	}

	[Native]
	public enum CSFForceFieldMetadataType : long
	{
		Unknown,
		Base64,
		Boolean,
		ComboBox,
		Currency,
		Date,
		DateTime,
		Double,
		Email,
		EncryptedString,
		Id,
		Integer,
		Int,
		MultiPickList,
		Percent,
		Phone,
		PickList,
		String,
		Reference,
		TextArea,
		Time,
		Url
	}

	[Native]
	public enum CSFForceTaskStatus : long
	{
		Unknown,
		NotStarted,
		InProgress,
		Completed,
		Waitingonsomeoneelse,
		Deferred
	}

	[Native]
	public enum CSFForceTaskPriority : long
	{
		Unknown,
		High,
		Normal,
		Low
	}

	[Native]
	public enum CSFForceTaskCallType : long
	{
		Unknown,
		Internal,
		Inbound,
		Outbound
	}

	[Native]
	public enum CSFForceTaskRecurrenceType : long
	{
		Unknown,
		RecursDaily,
		RecursEveryWeekday,
		RecursMonthly,
		RecursMonthyNth,
		RecursWeekly,
		RecursYearly,
		RecursYearlyNth
	}

	[Native]
	public enum CSFForceTaskRecurrenceInstance : long
	{
		Unknown,
		CSFForceTaskRecurrenceInstance1st,
		CSFForceTaskRecurrenceInstance2nd,
		CSFForceTaskRecurrenceInstance3rd,
		CSFForceTaskRecurrenceInstance4th,
		Last
	}

	[Native]
	public enum CSFForceTaskRecurrenceMonthOfYear : long
	{
		Unknown,
		January,
		February,
		March,
		April,
		May,
		June,
		July,
		August,
		September,
		October,
		November,
		December
	}

	[Native]
	public enum CSFForceRecordType : long
	{
		Other,
		Account,
		Contact,
		Task,
		Case,
		Contract,
		Opportunity,
		Quote,
		Lead,
		Campaign
	}

	static class CFunctions
	{
		// extern NSString * CSFForceStringValueForLayoutComponentType (CSFForceLayoutComponentType type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForLayoutComponentType (CSFForceLayoutComponentType type);

		// extern CSFForceLayoutComponentType CSFForceTypeForLayoutComponentTypeName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceLayoutComponentType CSFForceTypeForLayoutComponentTypeName (NSString name);

		// extern void CSFForcePrimitiveLayoutComponentTypeFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveLayoutComponentTypeFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForQuickActionType (CSFForceQuickActionType type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForQuickActionType (CSFForceQuickActionType type);

		// extern CSFForceQuickActionType CSFForceTypeForQuickActionTypeName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceQuickActionType CSFForceTypeForQuickActionTypeName (NSString name);

		// extern void CSFForcePrimitiveQuickActionTypeFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveQuickActionTypeFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForNotificationFrequency (CSFForceNotificationFrequency type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForNotificationFrequency (CSFForceNotificationFrequency type);

		// extern CSFForceNotificationFrequency CSFForceTypeForNotificationFrequencyName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceNotificationFrequency CSFForceTypeForNotificationFrequencyName (NSString name);

		// extern void CSFForcePrimitiveNotificationFrequencyFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveNotificationFrequencyFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForPortalRoleType (CSFForcePortalRoleType type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForPortalRoleType (CSFForcePortalRoleType type);

		// extern CSFForcePortalRoleType CSFForceTypeForPortalRoleTypeName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForcePortalRoleType CSFForceTypeForPortalRoleTypeName (NSString name);

		// extern void CSFForcePrimitivePortalRoleTypeFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitivePortalRoleTypeFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForPortalType (CSFForcePortalType type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForPortalType (CSFForcePortalType type);

		// extern CSFForcePortalType CSFForceTypeForPortalTypeName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForcePortalType CSFForceTypeForPortalTypeName (NSString name);

		// extern void CSFForcePrimitivePortalTypeFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitivePortalTypeFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForFieldMetadataType (CSFForceFieldMetadataType type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForFieldMetadataType (CSFForceFieldMetadataType type);

		// extern CSFForceFieldMetadataType CSFForceTypeForFieldMetadataTypeName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceFieldMetadataType CSFForceTypeForFieldMetadataTypeName (NSString name);

		// extern void CSFForcePrimitiveFieldMetadataTypeFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveFieldMetadataTypeFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForTaskStatus (CSFForceTaskStatus type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForTaskStatus (CSFForceTaskStatus type);

		// extern CSFForceTaskStatus CSFForceTypeForTaskStatusName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceTaskStatus CSFForceTypeForTaskStatusName (NSString name);

		// extern void CSFForcePrimitiveTaskStatusFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveTaskStatusFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForTaskPriority (CSFForceTaskPriority type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForTaskPriority (CSFForceTaskPriority type);

		// extern CSFForceTaskPriority CSFForceTypeForTaskPriorityName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceTaskPriority CSFForceTypeForTaskPriorityName (NSString name);

		// extern void CSFForcePrimitiveTaskPriorityFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveTaskPriorityFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForTaskCallType (CSFForceTaskCallType type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForTaskCallType (CSFForceTaskCallType type);

		// extern CSFForceTaskCallType CSFForceTypeForTaskCallTypeName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceTaskCallType CSFForceTypeForTaskCallTypeName (NSString name);

		// extern void CSFForcePrimitiveTaskCallTypeFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveTaskCallTypeFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForTaskRecurrenceType (CSFForceTaskRecurrenceType type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForTaskRecurrenceType (CSFForceTaskRecurrenceType type);

		// extern CSFForceTaskRecurrenceType CSFForceTypeForTaskRecurrenceTypeName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceTaskRecurrenceType CSFForceTypeForTaskRecurrenceTypeName (NSString name);

		// extern void CSFForcePrimitiveTaskRecurrenceTypeFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveTaskRecurrenceTypeFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForTaskRecurrenceInstance (CSFForceTaskRecurrenceInstance type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForTaskRecurrenceInstance (CSFForceTaskRecurrenceInstance type);

		// extern CSFForceTaskRecurrenceInstance CSFForceTypeForTaskRecurrenceInstanceName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceTaskRecurrenceInstance CSFForceTypeForTaskRecurrenceInstanceName (NSString name);

		// extern void CSFForcePrimitiveTaskRecurrenceInstanceFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveTaskRecurrenceInstanceFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForTaskRecurrenceMonthOfYear (CSFForceTaskRecurrenceMonthOfYear type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForTaskRecurrenceMonthOfYear (CSFForceTaskRecurrenceMonthOfYear type);

		// extern CSFForceTaskRecurrenceMonthOfYear CSFForceTypeForTaskRecurrenceMonthOfYearName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceTaskRecurrenceMonthOfYear CSFForceTypeForTaskRecurrenceMonthOfYearName (NSString name);

		// extern void CSFForcePrimitiveTaskRecurrenceMonthOfYearFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveTaskRecurrenceMonthOfYearFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * CSFForceStringValueForRecordType (CSFForceRecordType type) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString CSFForceStringValueForRecordType (CSFForceRecordType type);

		// extern CSFForceRecordType CSFForceTypeForRecordTypeName (NSString *name) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern CSFForceRecordType CSFForceTypeForRecordTypeName (NSString name);

		// extern void CSFForcePrimitiveRecordTypeFormatter (id value, CSFPrimitivePointer outputStruct) __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern void CSFForcePrimitiveRecordTypeFormatter (NSObject value, CSFPrimitivePointer outputStruct);

		// extern NSString * _Nullable SFKeyForUserAndScope (SFUserAccount * _Nullable user, SFUserAccountScope scope);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		//[return: NullAllowed]
		static extern NSString SFKeyForUserAndScope (/*[NullAllowed]*/ SFUserAccount user, SFUserAccountScope scope);
	}

	[Native]
	public enum SFEntityIdLength : ulong
	{
		SFEntityIdLength15 = 15,
		SFEntityIdLength18 = 18,
		Min = SFEntityIdLength15,
		Max = SFEntityIdLength18
	}

	//[Verify (InferredFromMemberPrefix)]
	public enum kSalesforceSDKManagerError : uint
	{
		Unknown = 766,
		InvalidLaunchParameters
	}

	[Native]
	public enum SFSDKLaunchAction : long
	{
		None = 0,
		Authenticated = 1 << 0,
		AlreadyAuthenticated = 1 << 1,
		AuthBypassed = 1 << 2,
		PasscodeVerified = 1 << 3
	}

	[Native]
	public enum SFOAuthLogLevel : ulong
	{
		Debug,
		Info,
		Warning,
		Error,
		Verbose
	}

	[Native]
	public enum SFOAuthCredentialsStorageType : long
	{
		None = -1,
		Keychain
	}

	//[Verify (InferredFromMemberPrefix)]
	public enum kSFOAuthError : uint
	{
		Unknown = 666,
		Timeout,
		Malformed,
		AccessDenied,
		InvalidClientId,
		InvalidClientCredentials,
		InvalidGrant,
		InvalidRequest,
		InactiveUser,
		InactiveOrg,
		RateLimitExceeded,
		UnsupportedResponseType,
		WrongVersion,
		BrowserLaunchFailed,
		UnknownAdvancedAuthConfig,
		InvalidMDMConfiguration,
		JWTInvalidGrant
	}

	[Native]
	public enum SFOAuthAdvancedAuthConfiguration : ulong
	{
		None = 0,
		Allow,
		Require
	}

	[Native]
	public enum SFOAuthAdvancedAuthState : ulong
	{
		NotStarted = 0,
		BrowserRequestInitiated,
		TokenRequestInitiated
	}

	[Native]
	public enum SFOAuthType : ulong
	{
		Unknown = 0,
		UserAgent,
		Refresh,
		AdvancedBrowser,
		JwtTokenExchange
	}

	[Native]
	public enum SFUserAccountAccessRestriction : ulong
	{
		None = 0,
		Chatter = 1 << 0,
		Rest = 1 << 1,
		Other = 1 << 2
	}

	[Native]
	public enum SFUserAccountScope : ulong
	{
		Global = 0,
		Org,
		User,
		Community
	}

	[Native]
	public enum SFUserAccountChange : ulong
	{
		Unknown = 1 << 0,
		NewUser = 1 << 1,
		Credentials = 1 << 2,
		OrgId = 1 << 3,
		UserId = 1 << 4,
		CommunityId = 1 << 5,
		IdData = 1 << 6
	}

	//[Verify (InferredFromMemberPrefix)]
	public enum kSFIdentityError : uint
	{
		Unknown = 766,
		NoData,
		DataMalformed,
		BadHttpResponse,
		MissingParameters,
		AlreadyRetrieving
	}

	[Native]
	public enum SFAuthenticationManagerDelegatePriority : ulong
	{
		Max = 0,
		High,
		Medium,
		Low,
		Default
	}

	[Native]
	public enum SFAppType : ulong
	{
		Native,
		Hybrid,
		ReactNative
	}

	[Native]
	public enum SFPasscodeControllerMode : ulong
	{
		Create,
		Verify,
		Change
	}

	[Native]
	public enum SFSecurityLockoutAction : ulong
	{
		None = 0,
		PasscodeCreated,
		PasscodeChanged,
		PasscodeVerified,
		PasscodeRemoved
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct SFPasscodeConfigurationData
	{
		public nint passcodeLength;

		public nuint lockoutTime;
	}

	[Native]
	public enum SFCryptoMode : ulong
	{
		InMemory,
		Disk
	}

	[Native]
	public enum SFCryptoOperation : ulong
	{
		Encrypt,
		Decrypt
	}

	[Native]
	public enum SFUserManagementAction : ulong
	{
		Cancel = 0,
		LogoutUser,
		SwitchUser,
		CreateNewUser
	}

	[Native]
	public enum SFKeyStoreKeyType : ulong
	{
		Generated = 0,
		Passcode
	}

	[Native]
	public enum SFKeychainItemExceptionErrorCode : ulong
	{
		SFKeychainItemExceptionKeychainInaccessible = 1
	}

	[Native]
	public enum SFLogFlag : ulong
	{
		Error = (1 << 0),
		Warning = (1 << 1),
		Info = (1 << 2),
		Debug = (1 << 3),
		Verbose = (1 << 4),
		NSLog = (1 << 5)
	}

	[Native]
	public enum SFLogLevel : ulong
	{
		Off = 0,
		Error = (SFLogFlag.Error),
		Warning = (Error | SFLogFlag.Warning),
		Info = (Warning | SFLogFlag.Info),
		Debug = (Info | SFLogFlag.Debug),
		Verbose = (Debug | SFLogFlag.Verbose),
		All = (Verbose | SFLogFlag.NSLog)
	}

	[Native]
	public enum SFLogContext : ulong
	{
		MobileSDKLogContext = 1
	}

	[Native]
	public enum SFOAuthCryptoOperation : ulong
	{
		Encrypt = 0,
		Decrypt
	}

	[Native]
	public enum SFOAuthSessionRefreshErrorCode : ulong
	{
		SFOAuthSessionRefreshErrorCodeInvalidCredentials = 766
	}

	[Native]
	public enum SFRestMethod : long
	{
		Get = 0,
		Post,
		Put,
		Delete,
		Head,
		Patch
	}

	[Native]
	public enum SFAccountManagerServiceType : ulong
	{
		None = 0,
		OAuth,
		Identity
	}

	[Native]
	public enum UIDevicePlatform : ulong
	{
		Unknown,
		Simulator,
		SimulatoriPhone,
		SimulatoriPhone6,
		SimulatoriPhone6Plus,
		SimulatoriPad,
		SimulatorAppleTV,
		UIDevice1GiPhone,
		UIDevice3GiPhone,
		UIDevice3GSiPhone,
		UIDevice4iPhone,
		UIDevice4SiPhone,
		UIDevice5iPhone,
		UIDevice5CiPhone,
		UIDevice5SiPhone,
		UIDevice6iPhone,
		UIDevice6PlusiPhone,
		UIDevice6siPhone,
		UIDevice6sPlusiPhone,
		SEiPhone,
		UIDevice7iPhone,
		UIDevice7PlusiPhone,
		UIDevice1GiPod,
		UIDevice2GiPod,
		UIDevice3GiPod,
		UIDevice4GiPod,
		UIDevice1GiPad,
		UIDevice2GiPad,
		UIDevice3GiPad,
		UIDevice4GiPad,
		UIDevice1GiPadAir,
		UIDevice2GiPadAir,
		UIDevice1GiPadMini,
		UIDevice2GiPadMini,
		UIDevice3GiPadMini,
		AppleTV2,
		AppleTV3,
		AppleTV4,
		UnknowniPhone,
		UnknowniPod,
		UnknowniPad,
		UnknownAppleTV,
		Ifpga
	}

	[Native]
	public enum UIDeviceFamily : ulong
	{
		iPhone,
		iPod,
		iPad,
		AppleTV,
		Unknown
	}

}
