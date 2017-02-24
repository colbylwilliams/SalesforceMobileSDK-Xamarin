using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using WebKit;

namespace SalesforceMobileSDK.iOS
{
	/*
	The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	to the project by right-clicking (or Control-clicking) the folder containing this source
	file and clicking "Add files..." and then simply select the native library (or libraries)
	that you want to bind.

	When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	architectures that the native library supports and fills in that information for you,
	however, it cannot auto-detect any Frameworks or other system libraries that the
	native library may depend on, so you'll need to fill in that information yourself.

	Once you've done that, you're ready to move on to binding the API...


	Here is where you'd define your API definition for the native Objective-C library.

	For example, to bind the following Objective-C class:

	    @interface Widget : NSObject {
	    }

	The C# binding would look like this:

	    [BaseType (typeof (NSObject))]
	    interface Widget {
	    }

	To bind Objective-C properties, such as:

	    @property (nonatomic, readwrite, assign) CGPoint center;

	You would add a property definition in the C# interface like so:

	    [Export ("center")]
	    CGPoint Center { get; set; }

	To bind an Objective-C method, such as:

	    -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;

	You would add a method definition to the C# interface like so:

	    [Export ("doSomething:atIndex:")]
	    void DoSomething (NSObject object, int index);

	Objective-C "constructors" such as:

	    -(id)initWithElmo:(ElmoMuppet *)elmo;

	Can be bound as:

	    [Export ("initWithElmo:")]
	    IntPtr Constructor (ElmoMuppet elmo);

	For more information, see http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/
	*/

	// typedef NSData * _Nullable (^ _Nullable)(NSData * _Nullable) DataEncryptorBlock;
	delegate NSData DataEncryptorBlock ([NullAllowed] NSData arg0);

	// typedef NSData * _Nullable (^ _Nullable)(NSData * _Nullable) DataDecryptorBlock;
	delegate NSData DataDecryptorBlock ([NullAllowed] NSData arg0);

	// PART OF SALESFORCEANALYTICS
	// typedef void (^ _Nonnull)(SFSDKInstrumentationEventBuilder * _Nonnull) SFSDKInstrumentationEventBuilderBlock;
	// delegate void SFSDKInstrumentationEventBuilderBlock (SFSDKInstrumentationEventBuilder arg0);

	[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString * kSFSDKReachabilityChangedNotification;
		[Field ("kSFSDKReachabilityChangedNotification", "__Internal")]
		NSString kSFSDKReachabilityChangedNotification { get; }

		// extern NSString *const kCSFConnectVersion __attribute__((visibility("default")));
		[Field ("kCSFConnectVersion", "__Internal")]
		NSString kCSFConnectVersion { get; }

		// extern NSString *const CSFNetworkLogIdentifier __attribute__((visibility("default")));
		[Field ("CSFNetworkLogIdentifier", "__Internal")]
		NSString CSFNetworkLogIdentifier { get; }
	}

	// typedef void (^CSFActionResponseBlock)(CSFAction *, NSError *);
	delegate void CSFActionResponseBlock (CSFAction arg0, NSError arg1);

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const CSFNetworkErrorDomain __attribute__((visibility("default")));
		[Field ("CSFNetworkErrorDomain", "__Internal")]
		NSString CSFNetworkErrorDomain { get; }

		// extern NSString *const CSFNetworkErrorActionKey __attribute__((visibility("default")));
		[Field ("CSFNetworkErrorActionKey", "__Internal")]
		NSString CSFNetworkErrorActionKey { get; }

		// extern NSString *const CSFNetworkErrorAuthenticationFailureKey __attribute__((visibility("default")));
		[Field ("CSFNetworkErrorAuthenticationFailureKey", "__Internal")]
		NSString CSFNetworkErrorAuthenticationFailureKey { get; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const CSFValidationErrorDomain __attribute__((visibility("default")));
		[Field ("CSFValidationErrorDomain", "__Internal")]
		NSString CSFValidationErrorDomain { get; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const CSFNetworkInitializedNotification __attribute__((visibility("default")));
		[Field ("CSFNetworkInitializedNotification", "__Internal")]
		NSString CSFNetworkInitializedNotification { get; }
	}

	// @interface CSFAction : NSOperation
	[BaseType (typeof (NSOperation))]
	interface CSFAction
	{
		// @property (readonly, nonatomic, weak) CSFNetwork * _Nullable enqueuedNetwork;
		[NullAllowed, Export ("enqueuedNetwork", ArgumentSemantic.Weak)]
		CSFNetwork EnqueuedNetwork { get; }

		// @property (getter = isProgrammatic, nonatomic) BOOL programmatic;
		[Export ("programmatic")]
		bool Programmatic { [Bind ("isProgrammatic")] get; set; }

		// @property (nonatomic, weak) id _Nullable context;
		[NullAllowed, Export ("context", ArgumentSemantic.Weak)]
		NSObject Context { get; set; }

		// @property (nonatomic) BOOL enqueueIfNoNetwork;
		[Export ("enqueueIfNoNetwork")]
		bool EnqueueIfNoNetwork { get; set; }

		// @property (nonatomic) CSFActionExecutionCapType executionCapType;
		[Export ("executionCapType", ArgumentSemantic.Assign)]
		CSFActionExecutionCapType ExecutionCapType { get; set; }

		// @property (copy, nonatomic) NSURL * _Nonnull baseURL;
		[Export ("baseURL", ArgumentSemantic.Copy)]
		NSUrl BaseURL { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull verb;
		[Export ("verb")]
		string Verb { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull method;
		[Export ("method")]
		string Method { get; set; }

		// @property (readonly, copy, nonatomic) NSDictionary * _Nonnull allHTTPHeaderFields;
		[Export ("allHTTPHeaderFields", ArgumentSemantic.Copy)]
		NSDictionary AllHTTPHeaderFields { get; }

		// @property (readonly, nonatomic, strong) CSFParameterStorage * _Nonnull parameters;
		[Export ("parameters", ArgumentSemantic.Strong)]
		CSFParameterStorage Parameters { get; }

		// @property (copy, nonatomic) NSDictionary * _Nonnull userInfo;
		[Export ("userInfo", ArgumentSemantic.Copy)]
		NSDictionary UserInfo { get; set; }

		// @property (readonly, nonatomic, strong) NSObject<CSFActionModel> * _Nonnull outputModel;
		[Export ("outputModel", ArgumentSemantic.Strong)]
		ICSFActionModel OutputModel { get; }

		// @property (readonly, nonatomic, strong) id _Nonnull outputContent;
		[Export ("outputContent", ArgumentSemantic.Strong)]
		NSObject OutputContent { get; }

		// @property (readonly, nonatomic, strong) NSData * _Nonnull outputData;
		[Export ("outputData", ArgumentSemantic.Strong)]
		NSData OutputData { get; }

		// @property (readonly, assign, nonatomic) BOOL isDuplicateAction;
		[Export ("isDuplicateAction")]
		bool IsDuplicateAction { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull downloadLocation;
		[Export ("downloadLocation", ArgumentSemantic.Strong)]
		NSUrl DownloadLocation { get; }

		// @property (assign, nonatomic) BOOL requiresAuthentication;
		[Export ("requiresAuthentication")]
		bool RequiresAuthentication { get; set; }

		// @property (nonatomic, strong) Class<CSFActionModel> _Nonnull modelClass;
		[Export ("modelClass", ArgumentSemantic.Strong)]
		ICSFActionModel ModelClass { get; set; }

		// @property (nonatomic, strong) Class _Nonnull authRefreshClass;
		[Export ("authRefreshClass", ArgumentSemantic.Strong)]
		Class AuthRefreshClass { get; set; }

		// @property (nonatomic) NSTimeInterval timeoutInterval;
		[Export ("timeoutInterval")]
		double TimeoutInterval { get; set; }

		// @property (nonatomic, strong) NSHTTPURLResponse * _Nonnull httpResponse;
		[Export ("httpResponse", ArgumentSemantic.Strong)]
		NSHttpUrlResponse HttpResponse { get; set; }

		// @property (readonly, nonatomic) NSUInteger retryCount;
		[Export ("retryCount")]
		nuint RetryCount { get; }

		// @property (nonatomic) NSUInteger maxRetryCount;
		[Export ("maxRetryCount")]
		nuint MaxRetryCount { get; set; }

		// @property (nonatomic, strong) NSMutableData * _Nullable responseData;
		[NullAllowed, Export ("responseData", ArgumentSemantic.Strong)]
		NSMutableData ResponseData { get; set; }

		// @property (nonatomic) BOOL requireBackgroundSession __attribute__((availability(ios, introduced=8.0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("requireBackgroundSession")]
		bool RequireBackgroundSession { get; set; }

		// @property (copy, nonatomic) NSURL * _Nonnull url;
		[Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; set; }

		// @property (readonly, nonatomic, strong) NSProgress * _Nonnull progress;
		[Export ("progress", ArgumentSemantic.Strong)]
		NSProgress Progress { get; }

		// @property (getter = shouldCacheResponse, nonatomic) BOOL cacheResponse;
		[Export ("cacheResponse")]
		bool CacheResponse { [Bind ("shouldCacheResponse")] get; set; }

		// @property (copy, nonatomic) CSFActionResponseBlock _Nonnull responseBlock;
		[Export ("responseBlock", ArgumentSemantic.Copy)]
		CSFActionResponseBlock ResponseBlock { get; set; }

		// @property (nonatomic, strong) NSError * _Nonnull error;
		[Export ("error", ArgumentSemantic.Strong)]
		NSError Error { get; set; }

		// +(instancetype _Nonnull)actionWithHTTPMethod:(NSString * _Nonnull)method onURL:(NSURL * _Nonnull)url withResponseBlock:(CSFActionResponseBlock _Nonnull)responseBlock;
		[Static]
		[Export ("actionWithHTTPMethod:onURL:withResponseBlock:")]
		CSFAction ActionWithHTTPMethod (string method, NSUrl url, CSFActionResponseBlock responseBlock);

		// -(instancetype _Nonnull)initWithResponseBlock:(CSFActionResponseBlock _Nonnull)responseBlock __attribute__((objc_designated_initializer));
		[Export ("initWithResponseBlock:")]
		[DesignatedInitializer]
		IntPtr Constructor (CSFActionResponseBlock responseBlock);

		// -(void)setURL:(NSURL * _Nonnull)url __attribute__((deprecated("Use the url property instead.")));
		[Export ("setURL:")]
		void SetURL (NSUrl url);

		// -(NSString * _Nonnull)valueForHTTPHeaderField:(NSString * _Nonnull)field;
		[Export ("valueForHTTPHeaderField:")]
		string ValueForHTTPHeaderField (string field);

		// -(void)setValue:(NSString * _Nonnull)value forHTTPHeaderField:(NSString * _Nonnull)field;
		[Export ("setValue:forHTTPHeaderField:")]
		void SetValue (string value, string field);

		// -(void)removeValueForHTTPHeaderField:(NSString * _Nonnull)field;
		[Export ("removeValueForHTTPHeaderField:")]
		void RemoveValueForHTTPHeaderField (string field);

		// -(BOOL)isEqualToAction:(CSFAction * _Nonnull)action;
		[Export ("isEqualToAction:")]
		bool IsEqualToAction (CSFAction action);

		// -(BOOL)shouldRetryWithError:(NSError * _Nonnull)error;
		[Export ("shouldRetryWithError:")]
		bool ShouldRetryWithError (NSError error);

		// -(void)completeOperationWithError:(NSError * _Nullable)error;
		[Export ("completeOperationWithError:")]
		void CompleteOperationWithError ([NullAllowed] NSError error);

		// -(NSURLSessionTask * _Nonnull)sessionTaskToProcessRequest:(NSURLRequest * _Nonnull)request session:(NSURLSession * _Nonnull)session;
		[Export ("sessionTaskToProcessRequest:session:")]
		NSUrlSessionTask SessionTaskToProcessRequest (NSUrlRequest request, NSUrlSession session);

		// -(NSDictionary * _Nonnull)headersForAction;
		[Export ("headersForAction")]
		//[Verify (MethodToProperty)]
		NSDictionary HeadersForAction { get; }

		// -(id _Nonnull)contentFromData:(NSData * _Nonnull)data fromResponse:(NSHTTPURLResponse * _Nonnull)response error:(NSError * _Nullable * _Nullable)error;
		[Export ("contentFromData:fromResponse:error:")]
		NSObject ContentFromData (NSData data, NSHttpUrlResponse response, [NullAllowed] out NSError error);

		// -(NSError * _Nonnull)errorFromData:(NSData * _Nonnull)data response:(NSHTTPURLResponse * _Nonnull)response;
		[Export ("errorFromData:response:")]
		NSError ErrorFromData (NSData data, NSHttpUrlResponse response);

		// -(BOOL)overrideRequest:(NSURLRequest * _Nonnull)request withResponseData:(NSData * _Nullable * _Nonnull)data andHTTPResponse:(NSHTTPURLResponse * _Nullable * _Nonnull)response;
		[Export ("overrideRequest:withResponseData:andHTTPResponse:")]
		bool OverrideRequest (NSUrlRequest request, [NullAllowed] out NSData data, [NullAllowed] out NSHttpUrlResponse response);

		// -(BOOL)shouldReportProgressToParent;
		[Export ("shouldReportProgressToParent")]
		//[Verify (MethodToProperty)]
		bool ShouldReportProgressToParent { get; }

		// -(void)sessionDataTask:(NSURLSessionDataTask * _Nonnull)task didReceiveData:(NSData * _Nonnull)data;
		[Export ("sessionDataTask:didReceiveData:")]
		void SessionDataTask (NSUrlSessionDataTask task, NSData data);

		// -(void)sessionTask:(NSURLSessionTask * _Nonnull)task didCompleteWithError:(NSError * _Nonnull)error;
		[Export ("sessionTask:didCompleteWithError:")]
		void SessionTask (NSUrlSessionTask task, NSError error);

		// -(void)sessionTask:(NSURLSessionTask * _Nonnull)task willPerformHTTPRedirection:(NSHTTPURLResponse * _Nonnull)response newRequest:(NSURLRequest * _Nonnull)request completionHandler:(void (^ _Nonnull)(NSURLRequest * _Nonnull))completionHandler;
		[Export ("sessionTask:willPerformHTTPRedirection:newRequest:completionHandler:")]
		void SessionTask (NSUrlSessionTask task, NSHttpUrlResponse response, NSUrlRequest request, Action<NSUrlRequest> completionHandler);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern CSFActionTiming _Nonnull kCSFActionTimingTotalTimeKey __attribute__((visibility("default")));
		[Field ("kCSFActionTimingTotalTimeKey", "__Internal")]
		NSString kCSFActionTimingTotalTimeKey { get; }

		// extern CSFActionTiming _Nonnull kCSFActionTimingNetworkTimeKey __attribute__((visibility("default")));
		[Field ("kCSFActionTimingNetworkTimeKey", "__Internal")]
		NSString kCSFActionTimingNetworkTimeKey { get; }

		// extern CSFActionTiming _Nonnull kCSFActionTimingStartDelayKey __attribute__((visibility("default")));
		[Field ("kCSFActionTimingStartDelayKey", "__Internal")]
		NSString kCSFActionTimingStartDelayKey { get; }

		// extern CSFActionTiming _Nonnull kCSFActionTimingPostProcessingKey __attribute__((visibility("default")));
		[Field ("kCSFActionTimingPostProcessingKey", "__Internal")]
		NSString kCSFActionTimingPostProcessingKey { get; }
	}

	// @interface Timing (CSFAction)
	[Category]
	[BaseType (typeof (CSFAction))]
	interface CSFAction_Timing
	{
		// -(NSTimeInterval)intervalForTimingKey:(CSFActionTiming _Nonnull)key;
		[Export ("intervalForTimingKey:")]
		double IntervalForTimingKey (string key);
	}

	// @protocol CSFActionInput <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface ICSFActionInput
	{
		// @required -(NSData *)formatJSONData:(NSError **)error;
		[Abstract]
		[Export ("formatJSONData:")]
		NSData FormatJSONData (out NSError error);
	}

	// @protocol CSFActionModel <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface ICSFActionModel
	{
		// @optional -(id)initWithJSON:(NSDictionary *)json context:(NSDictionary *)context;
		[Export ("initWithJSON:context:")]
		IntPtr Context (NSDictionary json, NSDictionary context);
	}

	// @protocol CSFActionValue <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface CSFActionValue
	{
		// @required -(id)actionValue;
		[Abstract]
		[Export ("actionValue")]
		//[Verify (MethodToProperty)]
		NSObject ActionValue { get; }

		// @optional +(id<CSFActionValue>)decodedObjectForActionValue:(id)actionValue;
		[Static]
		[Export ("decodedObjectForActionValue:")]
		CSFActionValue DecodedObjectForActionValue (NSObject actionValue);
	}

	// typedef void (^CSFAuthRefreshCompletionBlock)(CSFOutput *, NSError *);
	delegate void CSFAuthRefreshCompletionBlock (CSFOutput arg0, NSError arg1);

	// @interface CSFAuthRefresh : NSObject
	[BaseType (typeof (NSObject))]
	interface CSFAuthRefresh
	{
		// -(instancetype)initWithNetwork:(CSFNetwork *)network;
		[Export ("initWithNetwork:")]
		IntPtr Constructor (CSFNetwork network);

		// -(void)refreshAuthWithCompletionBlock:(CSFAuthRefreshCompletionBlock)completionBlock;
		[Export ("refreshAuthWithCompletionBlock:")]
		void RefreshAuthWithCompletionBlock (CSFAuthRefreshCompletionBlock completionBlock);

		// +(BOOL)isRefreshing;
		[Static]
		[Export ("isRefreshing")]
		//[Verify (MethodToProperty)]
		bool IsRefreshing { get; }
	}

	// @protocol CSFIndexedEntity <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface CSFIndexedEntity
	{
		// @required -(NSString *)indexedKey;
		[Abstract]
		[Export ("indexedKey")]
		//[Verify (MethodToProperty)]
		string IndexedKey { get; }

		// @required -(id)indexedValue;
		[Abstract]
		[Export ("indexedValue")]
		//[Verify (MethodToProperty)]
		NSObject IndexedValue { get; }
	}

	// @interface CSFInput : NSObject <NSSecureCoding, NSCopying, CSFActionInput>
	[BaseType (typeof (NSObject))]
	interface CSFInput : INSSecureCoding, INSCopying, ICSFActionInput
	{
		// -(BOOL)isEqualToInput:(CSFInput *)model;
		[Export ("isEqualToInput:")]
		bool IsEqualToInput (CSFInput model);
	}

	// @interface KeyedSubscript (CSFInput)
	[Category]
	[BaseType (typeof (CSFInput))]
	interface CSFInput_KeyedSubscript
	{
		// -(id)objectForKeyedSubscript:(id)key;
		[Export ("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript (NSObject key);

		// -(void)setObject:(id)obj forKeyedSubscript:(id<NSCopying>)key;
		[Export ("setObject:forKeyedSubscript:")]
		void SetObject (NSObject obj, NSCopying key);
	}

	// @interface DynamicProperties (CSFInput)
	[Category]
	[BaseType (typeof (CSFInput))]
	interface CSFInput_DynamicProperties
	{
		// +(BOOL)allowsCustomAttributes;
		[Static]
		[Export ("allowsCustomAttributes")]
		//[Verify (MethodToProperty)]
		bool AllowsCustomAttributes { get; }

		// +(NSString *)storageKeyForPropertyName:(NSString *)propertyName;
		[Static]
		[Export ("storageKeyForPropertyName:")]
		string StorageKeyForPropertyName (string propertyName);
	}

	// @interface CSFNetwork : NSObject
	[BaseType (typeof (NSObject))]
	interface CSFNetwork
	{
		// @property (readonly, nonatomic, strong) NSURLSession * ephemeralSession;
		[Export ("ephemeralSession", ArgumentSemantic.Strong)]
		NSUrlSession EphemeralSession { get; }

		// @property (getter = isNetworkSuspended, assign, nonatomic) BOOL networkSuspended;
		[Export ("networkSuspended")]
		bool NetworkSuspended { [Bind ("isNetworkSuspended")] get; set; }

		// @property (readonly, getter = isOnline, nonatomic) BOOL online;
		[Export ("online")]
		bool Online { [Bind ("isOnline")] get; }

		// @property (readonly, assign, nonatomic) NSUInteger actionCount;
		[Export ("actionCount")]
		nuint ActionCount { get; }

		// @property (readonly, nonatomic, strong) SFUserAccount * account;
		[Export ("account", ArgumentSemantic.Strong)]
		SFUserAccount Account { get; }

		// @property (readonly, getter = isRefreshingAccessToken, atomic) BOOL refreshingAccessToken;
		[Export ("refreshingAccessToken")]
		bool RefreshingAccessToken { [Bind ("isRefreshingAccessToken")] get; }

		// @property (readonly, nonatomic, strong) NSProgress * progress;
		[Export ("progress", ArgumentSemantic.Strong)]
		NSProgress Progress { get; }

		// +(instancetype)currentNetwork;
		[Static]
		[Export ("currentNetwork")]
		CSFNetwork CurrentNetwork ();

		// +(instancetype)networkForUserAccount:(SFUserAccount *)account;
		[Static]
		[Export ("networkForUserAccount:")]
		CSFNetwork NetworkForUserAccount (SFUserAccount account);

		// -(void)executeAction:(CSFAction *)action;
		[Export ("executeAction:")]
		void ExecuteAction (CSFAction action);

		// -(void)executeActions:(NSArray *)actions completionBlock:(void (^)(NSArray *, NSArray *))completionBlock;
		[Export ("executeActions:completionBlock:")]
		//[Verify (StronglyTypedNSArray)]
		void ExecuteActions (CSFAction [] actions, Action<NSArray, NSArray> completionBlock);

		// -(void)cancelAllActions;
		[Export ("cancelAllActions")]
		void CancelAllActions ();

		// -(void)cancelAllActionsWithContext:(id)context;
		[Export ("cancelAllActionsWithContext:")]
		void CancelAllActionsWithContext (NSObject context);

		// -(NSArray *)actionsWithContext:(id)context;
		[Export ("actionsWithContext:")]
		//[Verify (StronglyTypedNSArray)]
		NSBlockOperation [] ActionsWithContext (NSObject context);

		// @property (copy, nonatomic) NSString * securityToken;
		[Export ("securityToken")]
		string SecurityToken { get; set; }

		// -(void)addDelegate:(id<CSFNetworkDelegate>)delegate;
		[Export ("addDelegate:")]
		void AddDelegate (CSFNetworkDelegate @delegate);

		// -(void)removeDelegate:(id<CSFNetworkDelegate>)delegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (CSFNetworkDelegate @delegate);
	}

	// @interface Salesforce (CSFNetwork)
	[Category]
	[BaseType (typeof (CSFNetwork))]
	interface CSFNetwork_Salesforce
	{
		// @property (copy, nonatomic) NSString * defaultConnectCommunityId;
		[Static]
		[Export ("defaultConnectCommunityId")]
		string DefaultConnectCommunityId { get; set; }
	}

	// @interface Caching (CSFNetwork)
	[Category]
	[BaseType (typeof (CSFNetwork))]
	interface CSFNetwork_Caching
	{
		// @property (getter = isOfflineCacheEnabled, assign, nonatomic) BOOL offlineCacheEnabled;
		[Static]
		[Export ("offlineCacheEnabled")]
		bool OfflineCacheEnabled { [Bind ("isOfflineCacheEnabled")] get; set; }

		// @property (readonly, copy, nonatomic) NSArray * outputCaches;
		[Static]
		[Export ("outputCaches", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		CSFNetworkOutputCache [] OutputCaches { get; }

		// -(void)addOutputCache:(NSObject<CSFNetworkOutputCache> *)outputCache;
		[Static]
		[Export ("addOutputCache:")]
		void AddOutputCache (CSFNetworkOutputCache outputCache);

		// -(void)removeOutputCache:(NSObject<CSFNetworkOutputCache> *)outputCache;
		[Static]
		[Export ("removeOutputCache:")]
		void RemoveOutputCache (CSFNetworkOutputCache outputCache);
	}

	// @protocol CSFNetworkDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface CSFNetworkDelegate
	{
		// @optional -(void)network:(CSFNetwork *)network willEnqueueAction:(CSFAction *)action;
		[Export ("network:willEnqueueAction:")]
		void WillEnqueueAction (CSFNetwork network, CSFAction action);

		// @optional -(void)network:(CSFNetwork *)network didStartAction:(CSFAction *)action;
		[Export ("network:didStartAction:")]
		void DidStartAction (CSFNetwork network, CSFAction action);

		// @optional -(void)network:(CSFNetwork *)network didCancelAction:(CSFAction *)action;
		[Export ("network:didCancelAction:")]
		void DidCancelAction (CSFNetwork network, CSFAction action);

		// @optional -(void)network:(CSFNetwork *)network didCompleteAction:(CSFAction *)action withError:(NSError *)error;
		[Export ("network:didCompleteAction:withError:")]
		void DidCompleteAction (CSFNetwork network, CSFAction action, NSError error);

		// @optional -(void)network:(CSFNetwork *)network sessionTask:(NSURLSessionTask *)task changedState:(NSURLSessionTaskState)oldState toState:(NSURLSessionTaskState)newState forAction:(CSFAction *)action;
		[Export ("network:sessionTask:changedState:toState:forAction:")]
		void SessionTask (CSFNetwork network, NSUrlSessionTask task, NSUrlSessionTaskState oldState, NSUrlSessionTaskState newState, CSFAction action);
	}

	// @protocol CSFNetworkOutputCache <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface CSFNetworkOutputCache
	{
		// @required -(void)cacheOutputFromAction:(CSFAction *)action completionBlock:(void (^)(NSError *))completionBlock;
		[Abstract]
		[Export ("cacheOutputFromAction:completionBlock:")]
		void CacheOutputFromAction (CSFAction action, Action<NSError> completionBlock);

		// @required -(BOOL)shouldCacheOutputFromAction:(CSFAction *)action;
		[Abstract]
		[Export ("shouldCacheOutputFromAction:")]
		bool ShouldCacheOutputFromAction (CSFAction action);

		// @optional +(NSObject<CSFNetworkOutputCache> *)cacheInstanceForNetwork:(CSFNetwork *)network;
		[Static]
		[Export ("cacheInstanceForNetwork:")]
		CSFNetworkOutputCache CacheInstanceForNetwork (CSFNetwork network);
	}

	// @interface CSFOutput : NSObject <NSSecureCoding, NSCopying, CSFActionModel>
	[BaseType (typeof (NSObject))]
	interface CSFOutput : INSSecureCoding, INSCopying, ICSFActionModel
	{
		// -(instancetype)initWithJSON:(NSDictionary *)json context:(NSDictionary *)context __attribute__((objc_designated_initializer));
		[Export ("initWithJSON:context:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSDictionary json, NSDictionary context);

		// -(BOOL)isEqualToOutput:(CSFOutput *)model;
		[Export ("isEqualToOutput:")]
		bool IsEqualToOutput (CSFOutput model);
	}

	// @interface Ancestry (CSFOutput)
	[Category]
	[BaseType (typeof (CSFOutput))]
	interface CSFOutput_Ancestry
	{
		// @property (readonly, nonatomic, weak) NSObject * parentObject;
		[Static]
		[Export ("parentObject", ArgumentSemantic.Weak)]
		NSObject ParentObject { get; }
	}

	// @interface KeyedSubscript (CSFOutput)
	[Category]
	[BaseType (typeof (CSFOutput))]
	interface CSFOutput_KeyedSubscript
	{
		// -(id)objectForKeyedSubscript:(id)key;
		[Static]
		[Export ("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript (NSObject key);

		// -(void)setObject:(id)obj forKeyedSubscript:(id<NSCopying>)key;
		[Static]
		[Export ("setObject:forKeyedSubscript:")]
		void SetObject (NSObject obj, NSCopying key);
	}

	// @interface DynamicProperties (CSFOutput)
	[Category]
	[BaseType (typeof (CSFOutput))]
	interface CSFOutput_DynamicProperties
	{
		// +(NSString *)storageKeyPathForPropertyName:(NSString *)propertyName;
		[Static]
		[Export ("storageKeyPathForPropertyName:")]
		string StorageKeyPathForPropertyName (string propertyName);

		// +(BOOL)isDefaultPropertyForArray:(NSString *)propertyName;
		[Static]
		[Export ("isDefaultPropertyForArray:")]
		bool IsDefaultPropertyForArray (string propertyName);

		// +(Class<CSFActionModel>)actionModelForPropertyName:(NSString *)propertyName propertyClass:(Class)originalClass contents:(id)contents;
		[Static]
		[Export ("actionModelForPropertyName:propertyClass:contents:")]
		ICSFActionModel ActionModelForPropertyName (string propertyName, Class originalClass, NSObject contents);

		// -(id)transformedValueForProperty:(NSString *)propertyName propertyClass:(Class)propertyClass value:(id)value;
		[Export ("transformedValueForProperty:propertyClass:value:")]
		NSObject TransformedValueForProperty (string propertyName, Class propertyClass, NSObject value);

		// +(CSFPrimitiveFormatterPtr)actionModelFormatterForPrimitiveProperty:(NSString *)propertyName encodingType:(const char *)encodingType;
		[Static]
		[Export ("actionModelFormatterForPrimitiveProperty:encodingType:")]
		unsafe CSFPrimitivePointer ActionModelFormatterForPrimitiveProperty (string propertyName, sbyte encodingType);
	}

	// @interface CSFParameterStorage : NSObject
	[BaseType (typeof (NSObject))]
	interface CSFParameterStorage
	{
		// @property (readonly, assign, nonatomic) CSFParameterStyle parameterStyle;
		[Export ("parameterStyle", ArgumentSemantic.Assign)]
		CSFParameterStyle ParameterStyle { get; }

		// @property (copy, nonatomic) NSInputStream * (^bodyStreamBlock)();
		[Export ("bodyStreamBlock", ArgumentSemantic.Copy)]
		Func<NSInputStream> BodyStreamBlock { get; set; }

		// @property (readonly, copy, nonatomic) NSArray * allKeys;
		[Export ("allKeys", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		string [] AllKeys { get; }

		// @property (copy, nonatomic) NSSet * queryStringKeys;
		[Export ("queryStringKeys", ArgumentSemantic.Copy)]
		NSSet QueryStringKeys { get; set; }

		// -(void)setObject:(id)object forKey:(NSString *)key;
		[Export ("setObject:forKey:")]
		void SetObject (NSObject @object, string key);

		// -(void)setObject:(id)object forKey:(NSString *)key filename:(NSString *)filename mimeType:(NSString *)mimeType;
		[Export ("setObject:forKey:filename:mimeType:")]
		void SetObject (NSObject @object, string key, string filename, string mimeType);

		// -(id)objectForKey:(NSString *)key;
		[Export ("objectForKey:")]
		NSObject ObjectForKey (string key);

		// -(NSString *)mimeTypeForKey:(NSString *)key;
		[Export ("mimeTypeForKey:")]
		string MimeTypeForKey (string key);

		// -(void)setMimeType:(NSString *)mimeType forKey:(NSString *)key;
		[Export ("setMimeType:forKey:")]
		void SetMimeType (string mimeType, string key);

		// -(NSString *)fileNameForKey:(NSString *)key;
		[Export ("fileNameForKey:")]
		string FileNameForKey (string key);

		// -(void)setFileName:(NSString *)fileName forKey:(NSString *)key;
		[Export ("setFileName:forKey:")]
		void SetFileName (string fileName, string key);
	}

	// @interface KeyedSubscript (CSFParameterStorage)
	[Category]
	[BaseType (typeof (CSFParameterStorage))]
	interface CSFParameterStorage_KeyedSubscript
	{
		// -(id)objectForKeyedSubscript:(NSString *)key;
		[Export ("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript (string key);

		// -(void)setObject:(id)obj forKeyedSubscript:(NSString *)key;
		[Export ("setObject:forKeyedSubscript:")]
		void SetObject (NSObject obj, string key);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull CSFSalesforceActionDefaultPathPrefix __attribute__((visibility("default")));
		[Field ("CSFSalesforceActionDefaultPathPrefix", "__Internal")]
		NSString CSFSalesforceActionDefaultPathPrefix { get; }

		// extern NSString *const _Nonnull CSFSalesforceDefaultAPIVersion __attribute__((visibility("default")));
		[Field ("CSFSalesforceDefaultAPIVersion", "__Internal")]
		NSString CSFSalesforceDefaultAPIVersion { get; }
	}

	// @interface CSFSalesforceAction : CSFAction
	[BaseType (typeof (CSFAction))]
	interface CSFSalesforceAction
	{
		// @property (readonly, nonatomic) BOOL requiresSecurityToken;
		[Export ("requiresSecurityToken")]
		bool RequiresSecurityToken { get; }

		// @property (readonly, nonatomic) BOOL returnsSecurityToken;
		[Export ("returnsSecurityToken")]
		bool ReturnsSecurityToken { get; }

		// @property (copy, nonatomic) NSString * _Nullable pathPrefix;
		[NullAllowed, Export ("pathPrefix")]
		string PathPrefix { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable apiVersion;
		[NullAllowed, Export ("apiVersion")]
		string ApiVersion { get; set; }

		// +(BOOL)isNetworkError:(NSError * _Nullable)error;
		[Static]
		[Export ("isNetworkError:")]
		bool IsNetworkError ([NullAllowed] NSError error);
	}

	// @interface SFAdditions (NSArray)
	[Category]
	[BaseType (typeof (NSArray))]
	interface NSArray_SFAdditions
	{
		// -(NSArray *)filteredArrayWithElementsOfClass:(Class)aClass;
		[Export ("filteredArrayWithElementsOfClass:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject [] FilteredArrayWithElementsOfClass (Class aClass);

		// -(NSArray *)filteredArrayWithValue:(id)value forKeyPath:(NSString *)key;
		[Export ("filteredArrayWithValue:forKeyPath:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject [] FilteredArrayWithValue (NSObject value, string key);

		// -(NSArray *)filteredArrayExcludingValue:(id)value forKeyPath:(NSString *)key;
		[Export ("filteredArrayExcludingValue:forKeyPath:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject [] FilteredArrayExcludingValue (NSObject value, string key);
	}

	// @interface SFBase64 (NSData)
	[Category]
	[BaseType (typeof (NSData))]
	interface NSData_SFBase64
	{
		// -(NSData *)randomDataOfLength:(size_t)length;
		[Export ("randomDataOfLength:")]
		NSData RandomDataOfLength (nuint length);

		// -(NSString *)newBase64Encoding;
		[Export ("newBase64Encoding")]
		//[Verify (MethodToProperty)]
		string NewBase64Encoding ();

		// -(NSString *)base64Encode;
		[Export ("base64Encode")]
		//[Verify (MethodToProperty)]
		string Base64Encode ();

		// -(id)initWithBase64String:(NSString *)base64;
		[Static]
		[Export ("initWithBase64String:")]
		IntPtr Create (string base64);

		// +(NSData *)dataFromBase64String:(NSString *)encoding;
		[Static]
		[Export ("dataFromBase64String:")]
		NSData DataFromBase64String (string encoding);
	}

	// @interface SFMD5 (NSData)
	[Category]
	[BaseType (typeof (NSData))]
	interface NSData_SFMD5
	{
		// -(NSString *)md5;
		[Export ("md5")]
		//[Verify (MethodToProperty)]
		string Md5 ();
	}

	// @interface SFzlib (NSData)
	[Category]
	[BaseType (typeof (NSData))]
	interface NSData_SFzlib
	{
		// -(NSData *)gzipInflate;
		[Export ("gzipInflate")]
		//[Verify (MethodToProperty)]
		NSData GzipInflate ();

		// -(NSData *)gzipDeflate;
		[Export ("gzipDeflate")]
		//[Verify (MethodToProperty)]
		NSData GzipDeflate ();
	}

	// @interface SFHexSupport (NSData)
	[Category]
	[BaseType (typeof (NSData))]
	interface NSData_SFHexSupport
	{
		// -(NSString *)newHexStringFromBytes;
		[Export ("newHexStringFromBytes")]
		//[Verify (MethodToProperty)]
		string NewHexStringFromBytes ();
	}

	// @interface SFSDKUtils (NSData)
	[Category]
	[BaseType (typeof (NSData))]
	interface NSData_SFSDKUtils
	{
		// -(NSString *)msdkBase64UrlString;
		[Export ("msdkBase64UrlString")]
		//[Verify (MethodToProperty)]
		string MsdkBase64UrlString ();

		// -(NSData *)msdkSha256Data;
		[Export ("msdkSha256Data")]
		//[Verify (MethodToProperty)]
		NSData MsdkSha256Data ();
	}

	// @interface SFAdditions (NSDictionary)
	[Category]
	[BaseType (typeof (NSDictionary))]
	interface NSDictionary_SFAdditions
	{
		// -(id)objectAtPath:(NSString *)path;
		[Export ("objectAtPath:")]
		NSObject ObjectAtPath (string path);

		// -(id)nonNullObjectForKey:(id)key;
		[Export ("nonNullObjectForKey:")]
		NSObject NonNullObjectForKey (NSObject key);

		// -(NSString *)jsonString;
		[Export ("jsonString")]
		//[Verify (MethodToProperty)]
		string JsonString ();
	}

	// @interface SFAdditions (NSNotificationCenter)
	[Category]
	[BaseType (typeof (NSNotificationCenter))]
	interface NSNotificationCenter_SFAdditions
	{
		// +(void)postNotificationOnceWithName:(NSString *)notificationName object:(id)object userInfo:(NSDictionary *)userInfo;
		[Static]
		[Export ("postNotificationOnceWithName:object:userInfo:")]
		void PostNotificationOnceWithName (string notificationName, NSObject @object, NSDictionary userInfo);

		// -(void)postNotificationOnMainThreadWithName:(NSString *)notificationName object:(id)object userInfo:(NSDictionary *)userInfo;
		[Export ("postNotificationOnMainThreadWithName:object:userInfo:")]
		void PostNotificationOnMainThreadWithName (string notificationName, NSObject @object, NSDictionary userInfo);
	}

	// typedef void (^SFThreadBlock)();
	delegate void SFThreadBlock ();

	// @interface SFBlocks (NSObject)
	[Category]
	[BaseType (typeof (NSObject))]
	interface NSObject_SFBlocks
	{
		// -(void)performBlock:(SFThreadBlock)block onThread:(NSThread *)thread waitUntilDone:(BOOL)waitUntilDone;
		[Export ("performBlock:onThread:waitUntilDone:")]
		void PerformBlock (SFThreadBlock block, NSThread thread, bool waitUntilDone);

		// -(void)performBlockOnGlobalQueue:(SFThreadBlock)block afterDelay:(NSTimeInterval)delay;
		[Export ("performBlockOnGlobalQueue:afterDelay:")]
		void PerformBlockOnGlobalQueue (SFThreadBlock block, double delay);

		// -(void)performBlockOnMainThread:(SFThreadBlock)block afterDelay:(NSTimeInterval)delay;
		[Export ("performBlockOnMainThread:afterDelay:")]
		void PerformBlockOnMainThread (SFThreadBlock block, double delay);

		// -(BOOL)waitForBlockCondition:(BOOL (^)(void))block timeout:(NSTimeInterval)duration;
		[Export ("waitForBlockCondition:timeout:")]
		bool WaitForBlockCondition (Func<bool> block, double duration);

		// -(void)synchronouslyExecuteBlockOnMainThread:(void (^)(void))block;
		[Export ("synchronouslyExecuteBlockOnMainThread:")]
		void SynchronouslyExecuteBlockOnMainThread (Action block);

		// -(void)asynchronouslyExecuteBlockOnMainThread:(void (^)(void))block;
		[Export ("asynchronouslyExecuteBlockOnMainThread:")]
		void AsynchronouslyExecuteBlockOnMainThread (Action block);

		// -(void)executeBlockOrDispatchIfNotMainThread:(void (^)(void))block;
		[Export ("executeBlockOrDispatchIfNotMainThread:")]
		void ExecuteBlockOrDispatchIfNotMainThread (Action block);
	}

	// @interface SFAdditions (NSString)
	[Category]
	[BaseType (typeof (NSString))]
	interface NSString_SFAdditions
	{
		// +(NSString *)stringWithHexData:(NSData *)data;
		[Static]
		[Export ("stringWithHexData:")]
		string StringWithHexData (NSData data);

		// -(NSData *)sha256;
		[Export ("sha256")]
		//[Verify (MethodToProperty)]
		NSData Sha256 ();// { get; }

		// +(NSString *)escapeXMLCharacter:(NSString *)value;
		[Static]
		[Export ("escapeXMLCharacter:")]
		string EscapeXMLCharacter (string value);

		// +(NSString *)unescapeXMLCharacter:(NSString *)value;
		[Static]
		[Export ("unescapeXMLCharacter:")]
		string UnescapeXMLCharacter (string value);

		// -(NSString *)trim;
		[Export ("trim")]
		//[Verify (MethodToProperty)]
		string Trim ();// { get; }

		// -(NSString *)redacted;
		[Export ("redacted")]
		//[Verify (MethodToProperty)]
		string Redacted ();// { get; }

		// -(NSString *)redactedWithPrefix:(NSUInteger)prefixLength;
		[Export ("redactedWithPrefix:")]
		string RedactedWithPrefix (nuint prefixLength);

		// +(BOOL)isEmpty:(NSString *)string;
		[Static]
		[Export ("isEmpty:")]
		bool IsEmpty (string @string);

		// -(NSString *)removeWhitespaces;
		[Export ("removeWhitespaces")]
		//[Verify (MethodToProperty)]
		string RemoveWhitespaces ();// { get; }

		// -(NSString *)stringByURLEncoding;
		[Export ("stringByURLEncoding")]
		//[Verify (MethodToProperty)]
		string StringByURLEncoding ();// { get; }

		// -(NSString *)stringByStrippingHTML;
		[Export ("stringByStrippingHTML")]
		//[Verify (MethodToProperty)]
		string StringByStrippingHTML ();// { get; }

		// -(NSString *)stringWithTitleCharacter;
		[Export ("stringWithTitleCharacter")]
		//[Verify (MethodToProperty)]
		string StringWithTitleCharacter ();// { get; }

		// -(NSDictionary *)queryStringComponents;
		[Export ("queryStringComponents")]
		//[Verify (MethodToProperty)]
		NSDictionary QueryStringComponents ();// { get; }

		// -(BOOL)isEmptyOrWhitespaceAndNewlines;
		[Export ("isEmptyOrWhitespaceAndNewlines")]
		//[Verify (MethodToProperty)]
		bool IsEmptyOrWhitespaceAndNewlines ();// { get; }

		// -(NSString *)entityId18;
		[Export ("entityId18")]
		//[Verify (MethodToProperty)]
		string EntityId18 ();// { get; }

		// -(BOOL)isEqualToEntityId:(NSString *)entityId;
		[Export ("isEqualToEntityId:")]
		bool IsEqualToEntityId (string entityId);
	}

	// @interface SFAdditions (NSURL)
	[Category]
	[BaseType (typeof (NSUrl))]
	interface NSURL_SFAdditions
	{
		// -(NSString *)valueForParameterName:(NSString *)name;
		[Export ("valueForParameterName:")]
		string ValueForParameterName (string name);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kSFRedactedQuerystringValue;
		[Field ("kSFRedactedQuerystringValue", "__Internal")]
		NSString kSFRedactedQuerystringValue { get; }
	}

	// @interface SFStringUtils (NSURL)
	[Category]
	[BaseType (typeof (NSUrl))]
	interface NSURL_SFStringUtils
	{
		// -(NSString *)redactedAbsoluteString:(NSArray *)queryStringParamsToRedact;
		[Export ("redactedAbsoluteString:")]
		//[Verify (StronglyTypedNSArray)]
		string RedactedAbsoluteString (string [] queryStringParamsToRedact);

		// +(NSString *)stringUrlWithBaseUrl:(NSURL *)baseUrl pathComponents:(NSArray *)pathComponents;
		[Static]
		[Export ("stringUrlWithBaseUrl:pathComponents:")]
		//[Verify (StronglyTypedNSArray)]
		string StringUrlWithBaseUrl (NSUrl baseUrl, string [] pathComponents);

		// +(NSString *)stringUrlWithScheme:(NSString *)scheme host:(NSString *)host port:(NSNumber *)port pathComponents:(NSArray *)pathComponents;
		[Static]
		[Export ("stringUrlWithScheme:host:port:pathComponents:")]
		//[Verify (StronglyTypedNSArray)]
		string StringUrlWithScheme (string scheme, string host, NSNumber port, string [] pathComponents);
	}

	// @interface SFAdditions (NSUserDefaults)
	[Category]
	[BaseType (typeof (NSUserDefaults))]
	interface NSUserDefaults_SFAdditions
	{
		// +(NSUserDefaults *)msdkUserDefaults;
		[Static]
		[Export ("msdkUserDefaults")]
		//[Verify (MethodToProperty)]
		NSUserDefaults MsdkUserDefaults { get; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kSalesforceSDKManagerErrorDomain;
		[Field ("kSalesforceSDKManagerErrorDomain", "__Internal")]
		NSString kSalesforceSDKManagerErrorDomain { get; }

		// extern NSString *const _Nonnull kSalesforceSDKManagerErrorDetailsKey;
		[Field ("kSalesforceSDKManagerErrorDetailsKey", "__Internal")]
		NSString kSalesforceSDKManagerErrorDetailsKey { get; }
	}

	// typedef void (^SFSDKPostLaunchCallbackBlock)(SFSDKLaunchAction);
	delegate void SFSDKPostLaunchCallbackBlock (SFSDKLaunchAction arg0);

	// typedef void (^SFSDKLaunchErrorCallbackBlock)(NSError * _Nonnull, SFSDKLaunchAction);
	delegate void SFSDKLaunchErrorCallbackBlock (NSError arg0, SFSDKLaunchAction arg1);

	// typedef void (^SFSDKLogoutCallbackBlock)();
	delegate void SFSDKLogoutCallbackBlock ();

	// typedef void (^SFSDKSwitchUserCallbackBlock)(SFUserAccount * _Nonnull, SFUserAccount * _Nonnull);
	delegate void SFSDKSwitchUserCallbackBlock (SFUserAccount arg0, SFUserAccount arg1);

	// typedef void (^SFSDKAppForegroundCallbackBlock)();
	delegate void SFSDKAppForegroundCallbackBlock ();

	// typedef NSString * _Nonnull (^SFSDKUserAgentCreationBlock)(NSString * _Nonnull);
	delegate string SFSDKUserAgentCreationBlock (string arg0);

	// @interface SFOAuthCredentials : NSObject <NSSecureCoding>
	[BaseType (typeof (NSObject))]
	interface SFOAuthCredentials : INSSecureCoding
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable protocol;
		[NullAllowed, Export ("protocol", ArgumentSemantic.Strong)]
		string Protocol { get; }

		// @property (copy, nonatomic) NSString * _Nullable domain;
		[NullAllowed, Export ("domain")]
		string Domain { get; set; }

		// @property (copy) NSString * _Nonnull identifier;
		[Export ("identifier")]
		string Identifier { get; set; }

		// @property (copy) NSString * _Nullable clientId;
		[NullAllowed, Export ("clientId")]
		string ClientId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable redirectUri;
		[NullAllowed, Export ("redirectUri")]
		string RedirectUri { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable activationCode;
		[NullAllowed, Export ("activationCode")]
		string ActivationCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable jwt;
		[NullAllowed, Export ("jwt")]
		string Jwt { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable refreshToken;
		[NullAllowed, Export ("refreshToken")]
		string RefreshToken { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accessToken;
		[NullAllowed, Export ("accessToken")]
		string AccessToken { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable organizationId;
		[NullAllowed, Export ("organizationId")]
		string OrganizationId { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable instanceUrl;
		[NullAllowed, Export ("instanceUrl", ArgumentSemantic.Copy)]
		NSUrl InstanceUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable communityId;
		[NullAllowed, Export ("communityId")]
		string CommunityId { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable communityUrl;
		[NullAllowed, Export ("communityUrl", ArgumentSemantic.Copy)]
		NSUrl CommunityUrl { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable issuedAt;
		[NullAllowed, Export ("issuedAt", ArgumentSemantic.Copy)]
		NSDate IssuedAt { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable identityUrl;
		[NullAllowed, Export ("identityUrl", ArgumentSemantic.Copy)]
		NSUrl IdentityUrl { get; set; }

		// @property (readonly, nonatomic) NSDictionary * _Nullable legacyIdentityInformation;
		[NullAllowed, Export ("legacyIdentityInformation")]
		NSDictionary LegacyIdentityInformation { get; }

		// @property (readonly) NSURL * _Nullable apiUrl;
		[NullAllowed, Export ("apiUrl")]
		NSUrl ApiUrl { get; }

		// @property (copy, nonatomic) NSString * _Nullable userId;
		[NullAllowed, Export ("userId")]
		string UserId { get; set; }

		// @property (assign, nonatomic) SFOAuthLogLevel logLevel;
		[Export ("logLevel", ArgumentSemantic.Assign)]
		SFOAuthLogLevel LogLevel { get; set; }

		// @property (readonly, getter = isEncrypted, nonatomic) BOOL encrypted;
		[Export ("encrypted")]
		bool Encrypted { [Bind ("isEncrypted")] get; }

		// @property (readonly, nonatomic) NSDictionary * _Nullable additionalOAuthFields;
		[NullAllowed, Export ("additionalOAuthFields")]
		NSDictionary AdditionalOAuthFields { get; }

		// -(instancetype _Nullable)initWithIdentifier:(NSString * _Nonnull)theIdentifier clientId:(NSString * _Nullable)theClientId encrypted:(BOOL)encrypted;
		[Export ("initWithIdentifier:clientId:encrypted:")]
		IntPtr Constructor (string theIdentifier, [NullAllowed] string theClientId, bool encrypted);

		// -(instancetype _Nullable)initWithIdentifier:(NSString * _Nonnull)theIdentifier clientId:(NSString * _Nullable)theClientId encrypted:(BOOL)encrypted storageType:(SFOAuthCredentialsStorageType)type;
		[Export ("initWithIdentifier:clientId:encrypted:storageType:")]
		IntPtr Constructor (string theIdentifier, [NullAllowed] string theClientId, bool encrypted, SFOAuthCredentialsStorageType type);

		// -(void)revoke;
		[Export ("revoke")]
		void Revoke ();

		// -(void)revokeAccessToken;
		[Export ("revokeAccessToken")]
		void RevokeAccessToken ();

		// -(void)revokeRefreshToken;
		[Export ("revokeRefreshToken")]
		void RevokeRefreshToken ();

		// -(void)revokeActivationCode;
		[Export ("revokeActivationCode")]
		void RevokeActivationCode ();
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const NSTimeInterval kSFOAuthDefaultTimeout;
		[Field ("kSFOAuthDefaultTimeout", "__Internal")]
		double kSFOAuthDefaultTimeout { get; }

		// extern NSString *const kSFOAuthErrorDomain;
		[Field ("kSFOAuthErrorDomain", "__Internal")]
		NSString kSFOAuthErrorDomain { get; }
	}

	// typedef void (^SFOAuthBrowserFlowCallbackBlock)(BOOL);
	delegate void SFOAuthBrowserFlowCallbackBlock (bool arg0);

	// @protocol SFOAuthCoordinatorDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface ISFOAuthCoordinatorDelegate
	{
		// @optional -(void)oauthCoordinator:(SFOAuthCoordinator *)coordinator willBeginAuthenticationWithView:(WKWebView *)view;
		[Export ("oauthCoordinator:willBeginAuthenticationWithView:")]
		void OauthCoordinatorWillBeginAuthentication (SFOAuthCoordinator coordinator, WKWebView view);

		// @optional -(void)oauthCoordinator:(SFOAuthCoordinator *)coordinator didStartLoad:(WKWebView *)view;
		[Export ("oauthCoordinator:didStartLoad:")]
		void OauthCoordinatorDidStartLoad (SFOAuthCoordinator coordinator, WKWebView view);

		// @optional -(void)oauthCoordinator:(SFOAuthCoordinator *)coordinator didFinishLoad:(WKWebView *)view error:(NSError *)errorOrNil;
		[Export ("oauthCoordinator:didFinishLoad:error:")]
		void OauthCoordinatorDidFinishLoad (SFOAuthCoordinator coordinator, WKWebView view, NSError errorOrNil);

		// @optional -(void)oauthCoordinatorDidAuthenticate:(SFOAuthCoordinator *)coordinator __attribute__((deprecated("")));
		[Export ("oauthCoordinatorDidAuthenticate:")]
		void OauthCoordinatorDidAuthenticate (SFOAuthCoordinator coordinator);

		// @optional -(void)oauthCoordinatorWillBeginAuthentication:(SFOAuthCoordinator *)coordinator authInfo:(SFOAuthInfo *)info;
		[Export ("oauthCoordinatorWillBeginAuthentication:authInfo:")]
		void OauthCoordinatorWillBeginAuthentication (SFOAuthCoordinator coordinator, SFOAuthInfo info);

		// @optional -(void)oauthCoordinatorDidAuthenticate:(SFOAuthCoordinator *)coordinator authInfo:(SFOAuthInfo *)info;
		[Export ("oauthCoordinatorDidAuthenticate:authInfo:")]
		void OauthCoordinatorDidAuthenticate (SFOAuthCoordinator coordinator, SFOAuthInfo info);

		// @optional -(void)oauthCoordinator:(SFOAuthCoordinator *)coordinator didFailWithError:(NSError *)error __attribute__((deprecated("")));
		[Export ("oauthCoordinator:didFailWithError:")]
		void OauthCoordinatorDidFail (SFOAuthCoordinator coordinator, NSError error);

		// @optional -(void)oauthCoordinator:(SFOAuthCoordinator *)coordinator didFailWithError:(NSError *)error authInfo:(SFOAuthInfo *)info;
		[Export ("oauthCoordinator:didFailWithError:authInfo:")]
		void OauthCoordinatorDidFail (SFOAuthCoordinator coordinator, NSError error, SFOAuthInfo info);

		// @optional -(BOOL)oauthCoordinatorIsNetworkAvailable:(SFOAuthCoordinator *)coordinator;
		[Export ("oauthCoordinatorIsNetworkAvailable:")]
		bool OauthCoordinatorIsNetworkAvailable (SFOAuthCoordinator coordinator);

		// @optional -(void)oauthCoordinator:(SFOAuthCoordinator *)coordinator willBeginBrowserAuthentication:(SFOAuthBrowserFlowCallbackBlock)callbackBlock;
		[Export ("oauthCoordinator:willBeginBrowserAuthentication:")]
		void OauthCoordinatorWillBeginBrowserAuthentication (SFOAuthCoordinator coordinator, SFOAuthBrowserFlowCallbackBlock callbackBlock);

		// @optional -(BOOL)oauthCoordinatorRetryAuthenticationOnApplicationDidBecomeActive:(SFOAuthCoordinator *)coordinator;
		[Export ("oauthCoordinatorRetryAuthenticationOnApplicationDidBecomeActive:")]
		bool OauthCoordinatorRetryAuthenticationOnApplicationDidBecomeActive (SFOAuthCoordinator coordinator);

		// @optional -(void)oauthCoordinator:(SFOAuthCoordinator *)coordinator displayAlertMessage:(NSString *)message completion:(dispatch_block_t)completion;
		[Export ("oauthCoordinator:displayAlertMessage:completion:")]
		void OauthCoordinatorDisplayAllertMessage (SFOAuthCoordinator coordinator, string message, Action completion);

		// @optional -(void)oauthCoordinator:(SFOAuthCoordinator *)coordinator displayConfirmationMessage:(NSString *)message completion:(void (^)(BOOL))completion;
		[Export ("oauthCoordinator:displayConfirmationMessage:completion:")]
		void OauthCoordinatorDisplayConfirmationMessage (SFOAuthCoordinator coordinator, string message, Action<bool> completion);

		// @required -(void)oauthCoordinator:(SFOAuthCoordinator *)coordinator didBeginAuthenticationWithView:(WKWebView *)view;
		[Abstract]
		[Export ("oauthCoordinator:didBeginAuthenticationWithView:")]
		void OauthCoordinatorDidBeginAuthentication (SFOAuthCoordinator coordinator, WKWebView view);
	}

	// @interface SFOAuthCoordinator : NSObject <WKNavigationDelegate, WKUIDelegate>
	[BaseType (typeof (NSObject))]
	interface SFOAuthCoordinator : IWKNavigationDelegate, IWKUIDelegate
	{
		// @property (nonatomic, strong) SFOAuthCredentials * credentials;
		[Export ("credentials", ArgumentSemantic.Strong)]
		SFOAuthCredentials Credentials { get; set; }

		[Wrap ("WeakDelegate")]
		ISFOAuthCoordinatorDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SFOAuthCoordinatorDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic) NSSet * scopes;
		[Export ("scopes", ArgumentSemantic.Copy)]
		NSSet Scopes { get; set; }

		// @property (assign, nonatomic) NSTimeInterval timeout;
		[Export ("timeout")]
		double Timeout { get; set; }

		// @property (assign, nonatomic) SFOAuthAdvancedAuthConfiguration advancedAuthConfiguration;
		[Export ("advancedAuthConfiguration", ArgumentSemantic.Assign)]
		SFOAuthAdvancedAuthConfiguration AdvancedAuthConfiguration { get; set; }

		// @property (readonly, nonatomic) SFOAuthAdvancedAuthState advancedAuthState;
		[Export ("advancedAuthState")]
		SFOAuthAdvancedAuthState AdvancedAuthState { get; }

		// @property (readonly, nonatomic) WKWebView * view;
		[Export ("view")]
		WKWebView View { get; }

		// @property (copy, nonatomic) NSString * userAgentForAuth;
		[Export ("userAgentForAuth")]
		string UserAgentForAuth { get; set; }

		// @property (nonatomic, strong) NSArray * additionalOAuthParameterKeys;
		[Export ("additionalOAuthParameterKeys", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		string [] AdditionalOAuthParameterKeys { get; set; }

		// @property (nonatomic, strong) NSDictionary * additionalTokenRefreshParams;
		[Export ("additionalTokenRefreshParams", ArgumentSemantic.Strong)]
		NSDictionary AdditionalTokenRefreshParams { get; set; }

		// -(id)initWithCredentials:(SFOAuthCredentials *)credentials;
		[Export ("initWithCredentials:")]
		IntPtr Constructor (SFOAuthCredentials credentials);

		// -(void)authenticate;
		[Export ("authenticate")]
		void Authenticate ();

		// -(void)authenticateWithCredentials:(SFOAuthCredentials *)credentials;
		[Export ("authenticateWithCredentials:")]
		void AuthenticateWithCredentials (SFOAuthCredentials credentials);

		// -(BOOL)isAuthenticating;
		[Export ("isAuthenticating")]
		//[Verify (MethodToProperty)]
		bool IsAuthenticating { get; }

		// -(void)stopAuthentication;
		[Export ("stopAuthentication")]
		void StopAuthentication ();

		// -(void)revokeAuthentication;
		[Export ("revokeAuthentication")]
		void RevokeAuthentication ();

		// -(BOOL)handleAdvancedAuthenticationResponse:(NSURL *)appUrlResponse;
		[Export ("handleAdvancedAuthenticationResponse:")]
		bool HandleAdvancedAuthenticationResponse (NSUrl appUrlResponse);
	}

	// @interface SFOAuthInfo : NSObject
	[BaseType (typeof (NSObject))]
	interface SFOAuthInfo
	{
		// @property (readonly, assign, nonatomic) SFOAuthType authType;
		[Export ("authType", ArgumentSemantic.Assign)]
		SFOAuthType AuthType { get; }

		// @property (readonly, nonatomic) NSString * authTypeDescription;
		[Export ("authTypeDescription")]
		string AuthTypeDescription { get; }

		// -(id)initWithAuthType:(SFOAuthType)authType;
		[Export ("initWithAuthType:")]
		IntPtr Constructor (SFOAuthType authType);
	}

	// @interface SFUserAccount : NSObject <NSSecureCoding>
	[BaseType (typeof (NSObject))]
	interface SFUserAccount : INSSecureCoding
	{
		// @property (copy, nonatomic) NSSet<NSString *> * _Nullable accessScopes;
		[NullAllowed, Export ("accessScopes", ArgumentSemantic.Copy)]
		NSSet<NSString> AccessScopes { get; set; }

		// @property (readonly, nonatomic) SFUserAccountIdentity * _Nonnull accountIdentity;
		[Export ("accountIdentity")]
		SFUserAccountIdentity AccountIdentity { get; }

		// @property (nonatomic, strong) SFOAuthCredentials * _Nonnull credentials;
		[Export ("credentials", ArgumentSemantic.Strong)]
		SFOAuthCredentials Credentials { get; set; }

		// @property (nonatomic, strong) SFIdentityData * _Nonnull idData;
		[Export ("idData", ArgumentSemantic.Strong)]
		SFIdentityData IdData { get; set; }

		// @property (readonly, copy, nonatomic) NSURL * _Nonnull apiUrl;
		[Export ("apiUrl", ArgumentSemantic.Copy)]
		NSUrl ApiUrl { get; }

		// @property (copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull organizationName;
		[Export ("organizationName")]
		string OrganizationName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull fullName;
		[Export ("fullName")]
		string FullName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull userName;
		[Export ("userName")]
		string UserName { get; set; }

		// @property (nonatomic, strong) UIImage * _Nullable photo;
		[NullAllowed, Export ("photo", ArgumentSemantic.Strong)]
		UIImage Photo { get; set; }

		// @property (nonatomic) SFUserAccountAccessRestriction accessRestrictions;
		[Export ("accessRestrictions", ArgumentSemantic.Assign)]
		SFUserAccountAccessRestriction AccessRestrictions { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable communityId;
		[NullAllowed, Export ("communityId")]
		string CommunityId { get; set; }

		// @property (copy, nonatomic) NSArray<SFCommunityData *> * _Nullable communities;
		[NullAllowed, Export ("communities", ArgumentSemantic.Copy)]
		SFCommunityData [] Communities { get; set; }

		// @property (readonly, getter = isGuestUser, nonatomic) BOOL guestUser;
		[Export ("guestUser")]
		bool GuestUser { [Bind ("isGuestUser")] get; }

		// @property (readonly, getter = isSessionValid, nonatomic) BOOL sessionValid;
		[Export ("sessionValid")]
		bool SessionValid { [Bind ("isSessionValid")] get; }

		// @property (readonly, getter = isUserDeleted, nonatomic) BOOL userDeleted;
		[Export ("userDeleted")]
		bool UserDeleted { [Bind ("isUserDeleted")] get; }

		// @property (readonly, getter = isTemporaryUser, nonatomic) BOOL temporaryUser;
		[Export ("temporaryUser")]
		bool TemporaryUser { [Bind ("isTemporaryUser")] get; }

		// @property (readonly, getter = isAnonymousUser, nonatomic) BOOL anonymousUser;
		[Export ("anonymousUser")]
		bool AnonymousUser { [Bind ("isAnonymousUser")] get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier;
		[Export ("initWithIdentifier:")]
		IntPtr Constructor (string identifier);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier clientId:(NSString * _Nonnull)clientId __attribute__((objc_designated_initializer));
		[Export ("initWithIdentifier:clientId:")]
		[DesignatedInitializer]
		IntPtr Constructor (string identifier, string clientId);

		// -(NSURL * _Nullable)communityUrlWithId:(NSString * _Nonnull)communityId;
		[Export ("communityUrlWithId:")]
		[return: NullAllowed]
		NSUrl CommunityUrlWithId (string communityId);

		// -(SFCommunityData * _Nullable)communityWithId:(NSString * _Nonnull)communityId;
		[Export ("communityWithId:")]
		[return: NullAllowed]
		SFCommunityData CommunityWithId (string communityId);

		// -(void)setCustomDataObject:(id<NSCoding> _Nonnull)object forKey:(id<NSCopying> _Nonnull)key;
		[Export ("setCustomDataObject:forKey:")]
		void SetCustomDataObject (NSCoding @object, NSCopying key);

		// -(void)removeCustomDataObjectForKey:(id _Nonnull)key;
		[Export ("removeCustomDataObjectForKey:")]
		void RemoveCustomDataObjectForKey (NSObject key);

		// -(id _Nullable)customDataObjectForKey:(id _Nonnull)key;
		[Export ("customDataObjectForKey:")]
		[return: NullAllowed]
		NSObject CustomDataObjectForKey (NSObject key);
	}

	// @interface SFUserAccountIdentity : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof (NSObject))]
	interface SFUserAccountIdentity : INSSecureCoding, INSCopying
	{
		// @property (copy, nonatomic) NSString * userId;
		[Export ("userId")]
		string UserId { get; set; }

		// @property (copy, nonatomic) NSString * orgId;
		[Export ("orgId")]
		string OrgId { get; set; }

		// +(SFUserAccountIdentity *)identityWithUserId:(NSString *)userId orgId:(NSString *)orgId;
		[Static]
		[Export ("identityWithUserId:orgId:")]
		SFUserAccountIdentity IdentityWithUserId (string userId, string orgId);

		// -(id)initWithUserId:(NSString *)userId orgId:(NSString *)orgId;
		[Export ("initWithUserId:orgId:")]
		IntPtr Constructor (string userId, string orgId);

		// -(NSComparisonResult)compare:(SFUserAccountIdentity *)otherIdentity;
		[Export ("compare:")]
		NSComparisonResult Compare (SFUserAccountIdentity otherIdentity);

		// -(BOOL)matchesCredentials:(SFOAuthCredentials *)credentials;
		[Export ("matchesCredentials:")]
		bool MatchesCredentials (SFOAuthCredentials credentials);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull SFUserAccountManagerDidChangeCurrentUserNotification;
		[Field ("SFUserAccountManagerDidChangeCurrentUserNotification", "__Internal")]
		NSString SFUserAccountManagerDidChangeCurrentUserNotification { get; }

		// extern NSString *const _Nonnull SFUserAccountManagerDidFinishUserInitNotification;
		[Field ("SFUserAccountManagerDidFinishUserInitNotification", "__Internal")]
		NSString SFUserAccountManagerDidFinishUserInitNotification { get; }

		// extern NSString *const _Nonnull SFUserAccountManagerUserChangeKey;
		[Field ("SFUserAccountManagerUserChangeKey", "__Internal")]
		NSString SFUserAccountManagerUserChangeKey { get; }

		// extern NSString *const _Nonnull kSFLoginHostChangedNotification;
		[Field ("kSFLoginHostChangedNotification", "__Internal")]
		NSString kSFLoginHostChangedNotification { get; }

		// extern NSString *const _Nonnull kSFLoginHostChangedNotificationOriginalHostKey;
		[Field ("kSFLoginHostChangedNotificationOriginalHostKey", "__Internal")]
		NSString kSFLoginHostChangedNotificationOriginalHostKey { get; }

		// extern NSString *const _Nonnull kSFLoginHostChangedNotificationUpdatedHostKey;
		[Field ("kSFLoginHostChangedNotificationUpdatedHostKey", "__Internal")]
		NSString kSFLoginHostChangedNotificationUpdatedHostKey { get; }
	}

	// @protocol SFUserAccountManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface ISFUserAccountManagerDelegate
	{
		// @optional -(void)userAccountManager:(SFUserAccountManager * _Nonnull)userAccountManager willSwitchFromUser:(SFUserAccount * _Nonnull)fromUser toUser:(SFUserAccount * _Nullable)toUser;
		[Export ("userAccountManager:willSwitchFromUser:toUser:")]
		void WillSwitchFromUser (SFUserAccountManager userAccountManager, SFUserAccount fromUser, [NullAllowed] SFUserAccount toUser);

		// @optional -(void)userAccountManager:(SFUserAccountManager * _Nonnull)userAccountManager didSwitchFromUser:(SFUserAccount * _Nonnull)fromUser toUser:(SFUserAccount * _Nullable)toUser;
		[Export ("userAccountManager:didSwitchFromUser:toUser:")]
		void DidSwitchFromUser (SFUserAccountManager userAccountManager, SFUserAccount fromUser, [NullAllowed] SFUserAccount toUser);
	}

	// @interface SFUserAccountManager : NSObject
	[BaseType (typeof (NSObject))]
	interface SFUserAccountManager
	{
		// @property (nonatomic, strong) SFUserAccount * _Nullable currentUser;
		[NullAllowed, Export ("currentUser", ArgumentSemantic.Strong)]
		SFUserAccount CurrentUser { get; set; }

		// @property (readonly, nonatomic) SFUserAccountIdentity * _Nullable temporaryUserIdentity;
		[NullAllowed, Export ("temporaryUserIdentity")]
		SFUserAccountIdentity TemporaryUserIdentity { get; }

		// @property (readonly, nonatomic) SFUserAccount * _Nullable temporaryUser;
		[NullAllowed, Export ("temporaryUser")]
		SFUserAccount TemporaryUser { get; }

		// @property (readonly, nonatomic) BOOL supportsAnonymousUser;
		[Export ("supportsAnonymousUser")]
		bool SupportsAnonymousUser { get; }

		// @property (readonly, nonatomic) BOOL autocreateAnonymousUser;
		[Export ("autocreateAnonymousUser")]
		bool AutocreateAnonymousUser { get; }

		// @property (readonly, nonatomic, strong) SFUserAccount * _Nullable anonymousUser;
		[NullAllowed, Export ("anonymousUser", ArgumentSemantic.Strong)]
		SFUserAccount AnonymousUser { get; }

		// @property (readonly, getter = isCurrentUserAnonymous, nonatomic) BOOL currentUserAnonymous;
		[Export ("currentUserAnonymous")]
		bool CurrentUserAnonymous { [Bind ("isCurrentUserAnonymous")] get; }

		// @property (readonly, nonatomic) SFUserAccountIdentity * _Nullable currentUserIdentity;
		[NullAllowed, Export ("currentUserIdentity")]
		SFUserAccountIdentity CurrentUserIdentity { get; }

		// @property (readonly, nonatomic) NSString * _Nullable currentCommunityId;
		[NullAllowed, Export ("currentCommunityId")]
		string CurrentCommunityId { get; }

		// @property (readonly, nonatomic) NSArray<SFUserAccount *> * _Nonnull allUserAccounts;
		[Export ("allUserAccounts")]
		SFUserAccount [] AllUserAccounts { get; }

		// @property (readonly, nonatomic) NSArray<SFUserAccountIdentity *> * _Nonnull allUserIdentities;
		[Export ("allUserIdentities")]
		SFUserAccountIdentity [] AllUserIdentities { get; }

		// @property (copy, nonatomic) SFUserAccountIdentity * _Nullable activeUserIdentity;
		[NullAllowed, Export ("activeUserIdentity", ArgumentSemantic.Copy)]
		SFUserAccountIdentity ActiveUserIdentity { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable activeCommunityId;
		[NullAllowed, Export ("activeCommunityId")]
		string ActiveCommunityId { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable previousCommunityId;
		[NullAllowed, Export ("previousCommunityId", ArgumentSemantic.Strong)]
		string PreviousCommunityId { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable loginHost;
		[NullAllowed, Export ("loginHost", ArgumentSemantic.Strong)]
		string LoginHost { get; set; }

		// @property (assign, nonatomic) BOOL retryLoginAfterFailure;
		[Export ("retryLoginAfterFailure")]
		bool RetryLoginAfterFailure { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable oauthClientId;
		[NullAllowed, Export ("oauthClientId")]
		string OauthClientId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable oauthCompletionUrl;
		[NullAllowed, Export ("oauthCompletionUrl")]
		string OauthCompletionUrl { get; set; }

		// @property (copy, nonatomic) NSSet<NSString *> * _Nonnull scopes;
		[Export ("scopes", ArgumentSemantic.Copy)]
		NSSet<NSString> Scopes { get; set; }

		// +(instancetype _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		SFUserAccountManager SharedInstance ();

		// +(void)applyCurrentLogLevel:(SFOAuthCredentials * _Nonnull)credentials;
		[Static]
		[Export ("applyCurrentLogLevel:")]
		void ApplyCurrentLogLevel (SFOAuthCredentials credentials);

		// +(NSString * _Nonnull)userAccountPlistFileForUser:(SFUserAccount * _Nonnull)user;
		[Static]
		[Export ("userAccountPlistFileForUser:")]
		string UserAccountPlistFileForUser (SFUserAccount user);

		// +(void)setActiveUserIdentity:(SFUserAccountIdentity * _Nonnull)activeUserIdentity;
		[Static]
		[Export ("setActiveUserIdentity:")]
		void SetActiveUserIdentity (SFUserAccountIdentity activeUserIdentity);

		// -(void)addDelegate:(id<SFUserAccountManagerDelegate> _Nonnull)delegate;
		[Export ("addDelegate:")]
		void AddDelegate (ISFUserAccountManagerDelegate @delegate);

		// -(void)removeDelegate:(id<SFUserAccountManagerDelegate> _Nonnull)delegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (ISFUserAccountManagerDelegate @delegate);

		// -(BOOL)loadAccounts:(NSError * _Nullable * _Nullable)error;
		[Export ("loadAccounts:")]
		bool LoadAccounts ([NullAllowed] out NSError error);

		// -(BOOL)saveAccounts:(NSError * _Nullable * _Nullable)error;
		[Export ("saveAccounts:")]
		bool SaveAccounts ([NullAllowed] out NSError error);

		// -(SFUserAccount * _Nonnull)createUserAccount;
		[Export ("createUserAccount")]
		//[Verify (MethodToProperty)]
		SFUserAccount CreateUserAccount ();// { get; }

		// -(void)enableAnonymousAccount;
		[Export ("enableAnonymousAccount")]
		void EnableAnonymousAccount ();

		// -(SFUserAccount * _Nullable)userAccountForUserIdentity:(SFUserAccountIdentity * _Nonnull)userIdentity;
		[Export ("userAccountForUserIdentity:")]
		[return: NullAllowed]
		SFUserAccount UserAccountForUserIdentity (SFUserAccountIdentity userIdentity);

		// -(NSArray<SFUserAccount *> * _Nonnull)accountsForOrgId:(NSString * _Nonnull)orgId;
		[Export ("accountsForOrgId:")]
		SFUserAccount [] AccountsForOrgId (string orgId);

		// -(NSArray<SFUserAccount *> * _Nonnull)accountsForInstanceURL:(NSURL * _Nonnull)instanceURL;
		[Export ("accountsForInstanceURL:")]
		SFUserAccount [] AccountsForInstanceURL (NSUrl instanceURL);

		// -(void)addAccount:(SFUserAccount * _Nonnull)acct;
		[Export ("addAccount:")]
		void AddAccount (SFUserAccount acct);

		// -(BOOL)deleteAccountForUser:(SFUserAccount * _Nonnull)user error:(NSError * _Nullable * _Nullable)error;
		[Export ("deleteAccountForUser:error:")]
		bool DeleteAccountForUser (SFUserAccount user, [NullAllowed] out NSError error);

		// -(void)clearAllAccountState;
		[Export ("clearAllAccountState")]
		void ClearAllAccountState ();

		// -(void)applyCredentials:(SFOAuthCredentials * _Nonnull)credentials;
		[Export ("applyCredentials:")]
		void ApplyCredentials (SFOAuthCredentials credentials);

		// -(void)applyIdData:(SFIdentityData * _Nonnull)idData;
		[Export ("applyIdData:")]
		void ApplyIdData (SFIdentityData idData);

		// -(void)applyIdDataCustomAttributes:(NSDictionary * _Nonnull)customAttributes;
		[Export ("applyIdDataCustomAttributes:")]
		void ApplyIdDataCustomAttributes (NSDictionary customAttributes);

		// -(void)applyIdDataCustomPermissions:(NSDictionary * _Nonnull)customPermissions;
		[Export ("applyIdDataCustomPermissions:")]
		void ApplyIdDataCustomPermissions (NSDictionary customPermissions);

		// -(void)setObjectForCurrentUserCustomData:(NSObject<NSCoding> * _Nonnull)object forKey:(NSString * _Nonnull)key;
		[Export ("setObjectForCurrentUserCustomData:forKey:")]
		void SetObjectForCurrentUserCustomData (NSCoding @object, string key);

		// -(void)switchToNewUser;
		[Export ("switchToNewUser")]
		void SwitchToNewUser ();

		// -(void)switchToUser:(SFUserAccount * _Nullable)newCurrentUser;
		[Export ("switchToUser:")]
		void SwitchToUser ([NullAllowed] SFUserAccount newCurrentUser);

		// -(void)userChanged:(SFUserAccountChange)change;
		[Export ("userChanged:")]
		void UserChanged (SFUserAccountChange change);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const NSTimeInterval kSFIdentityRequestDefaultTimeoutSeconds;
		[Field ("kSFIdentityRequestDefaultTimeoutSeconds", "__Internal")]
		double kSFIdentityRequestDefaultTimeoutSeconds { get; }

		// extern NSString *const kSFIdentityErrorDomain;
		[Field ("kSFIdentityErrorDomain", "__Internal")]
		NSString kSFIdentityErrorDomain { get; }
	}

	// @protocol SFIdentityCoordinatorDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface ISFIdentityCoordinatorDelegate
	{
		// @required -(void)identityCoordinatorRetrievedData:(SFIdentityCoordinator *)coordinator;
		[Abstract]
		[Export ("identityCoordinatorRetrievedData:")]
		void IdentityCoordinatorRetrievedData (SFIdentityCoordinator coordinator);

		// @required -(void)identityCoordinator:(SFIdentityCoordinator *)coordinator didFailWithError:(NSError *)error;
		[Abstract]
		[Export ("identityCoordinator:didFailWithError:")]
		void IdentityCoordinator (SFIdentityCoordinator coordinator, NSError error);
	}

	// @interface SFIdentityCoordinator : NSObject
	[BaseType (typeof (NSObject))]
	interface SFIdentityCoordinator
	{
		// -(id)initWithCredentials:(SFOAuthCredentials *)credentials;
		[Export ("initWithCredentials:")]
		IntPtr Constructor (SFOAuthCredentials credentials);

		// -(void)initiateIdentityDataRetrieval;
		[Export ("initiateIdentityDataRetrieval")]
		void InitiateIdentityDataRetrieval ();

		// -(void)cancelRetrieval;
		[Export ("cancelRetrieval")]
		void CancelRetrieval ();

		// @property (nonatomic, strong) SFOAuthCredentials * credentials;
		[Export ("credentials", ArgumentSemantic.Strong)]
		SFOAuthCredentials Credentials { get; set; }

		// @property (nonatomic, strong) SFIdentityData * idData;
		[Export ("idData", ArgumentSemantic.Strong)]
		SFIdentityData IdData { get; set; }

		[Wrap ("WeakDelegate")]
		ISFIdentityCoordinatorDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SFIdentityCoordinatorDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) NSTimeInterval timeout;
		[Export ("timeout")]
		double Timeout { get; set; }
	}

	// typedef void (^SFOAuthFlowSuccessCallbackBlock)(SFOAuthInfo * _Nonnull);
	delegate void SFOAuthFlowSuccessCallbackBlock (SFOAuthInfo arg0);

	// typedef void (^SFOAuthFlowFailureCallbackBlock)(SFOAuthInfo * _Nonnull, NSError * _Nonnull);
	delegate void SFOAuthFlowFailureCallbackBlock (SFOAuthInfo arg0, NSError arg1);

	// @protocol SFAuthenticationManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface ISFAuthenticationManagerDelegate
	{
		// @optional -(void)authManagerWillBeginAuthWithView:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerWillBeginAuthWithView:")]
		void AuthManagerWillBeginAuthWithView (SFAuthenticationManager manager);

		// @optional -(void)authManagerDidStartAuthWebViewLoad:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerDidStartAuthWebViewLoad:")]
		void AuthManagerDidStartAuthWebViewLoad (SFAuthenticationManager manager);

		// @optional -(void)authManagerDidFinishAuthWebViewLoad:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerDidFinishAuthWebViewLoad:")]
		void AuthManagerDidFinishAuthWebViewLoad (SFAuthenticationManager manager);

		// @optional -(void)authManager:(SFAuthenticationManager * _Nonnull)manager willDisplayAuthWebView:(WKWebView * _Nonnull)view;
		[Export ("authManager:willDisplayAuthWebView:")]
		void AuthManager (SFAuthenticationManager manager, WKWebView view);

		// @optional -(void)authManagerWillBeginAuthentication:(SFAuthenticationManager * _Nonnull)manager authInfo:(SFOAuthInfo * _Nonnull)info;
		[Export ("authManagerWillBeginAuthentication:authInfo:")]
		void AuthManagerWillBeginAuthentication (SFAuthenticationManager manager, SFOAuthInfo info);

		// @optional -(void)authManagerDidAuthenticate:(SFAuthenticationManager * _Nonnull)manager credentials:(SFOAuthCredentials * _Nonnull)credentials authInfo:(SFOAuthInfo * _Nonnull)info;
		[Export ("authManagerDidAuthenticate:credentials:authInfo:")]
		void AuthManagerDidAuthenticate (SFAuthenticationManager manager, SFOAuthCredentials credentials, SFOAuthInfo info);

		// @optional -(void)authManagerDidFinish:(SFAuthenticationManager * _Nonnull)manager info:(SFOAuthInfo * _Nonnull)info;
		[Export ("authManagerDidFinish:info:")]
		void AuthManagerDidFinish (SFAuthenticationManager manager, SFOAuthInfo info);

		// @optional -(void)authManagerDidFail:(SFAuthenticationManager * _Nonnull)manager error:(NSError * _Nonnull)error info:(SFOAuthInfo * _Nonnull)info;
		[Export ("authManagerDidFail:error:info:")]
		void AuthManagerDidFail (SFAuthenticationManager manager, NSError error, SFOAuthInfo info);

		// @optional -(BOOL)authManagerIsNetworkAvailable:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerIsNetworkAvailable:")]
		bool AuthManagerIsNetworkAvailable (SFAuthenticationManager manager);

		// @optional -(void)authManager:(SFAuthenticationManager * _Nonnull)manager willLogoutUser:(SFUserAccount * _Nonnull)user;
		[Export ("authManager:willLogoutUser:")]
		void AuthManager (SFAuthenticationManager manager, SFUserAccount user);

		// @optional -(void)authManagerDidLogout:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerDidLogout:")]
		void AuthManagerDidLogout (SFAuthenticationManager manager);

		// @optional -(void)authManagerWillResignActive:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerWillResignActive:")]
		void AuthManagerWillResignActive (SFAuthenticationManager manager);

		// @optional -(void)authManagerDidBecomeActive:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerDidBecomeActive:")]
		void AuthManagerDidBecomeActive (SFAuthenticationManager manager);

		// @optional -(void)authManagerWillEnterForeground:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerWillEnterForeground:")]
		void AuthManagerWillEnterForeground (SFAuthenticationManager manager);

		// @optional -(void)authManagerDidEnterBackground:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerDidEnterBackground:")]
		void AuthManagerDidEnterBackground (SFAuthenticationManager manager);

		// @optional -(void)authManagerDidProceedWithBrowserFlow:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerDidProceedWithBrowserFlow:")]
		void AuthManagerDidProceedWithBrowserFlow (SFAuthenticationManager manager);

		// @optional -(void)authManagerDidCancelBrowserFlow:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerDidCancelBrowserFlow:")]
		void AuthManagerDidCancelBrowserFlow (SFAuthenticationManager manager);

		// @optional -(void)authManagerDidCancelGenericFlow:(SFAuthenticationManager * _Nonnull)manager;
		[Export ("authManagerDidCancelGenericFlow:")]
		void AuthManagerDidCancelGenericFlow (SFAuthenticationManager manager);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kSFUserWillLogoutNotification;
		[Field ("kSFUserWillLogoutNotification", "__Internal")]
		NSString kSFUserWillLogoutNotification { get; }

		// extern NSString *const _Nonnull kSFUserLogoutNotification;
		[Field ("kSFUserLogoutNotification", "__Internal")]
		NSString kSFUserLogoutNotification { get; }

		// extern NSString *const _Nonnull kSFUserLoggedInNotification;
		[Field ("kSFUserLoggedInNotification", "__Internal")]
		NSString kSFUserLoggedInNotification { get; }

		// extern NSString *const _Nonnull kSFAuthenticationManagerFinishedNotification;
		[Field ("kSFAuthenticationManagerFinishedNotification", "__Internal")]
		NSString kSFAuthenticationManagerFinishedNotification { get; }
	}

	// @interface SFAuthenticationManager : NSObject <SFOAuthCoordinatorDelegate, SFIdentityCoordinatorDelegate, SFUserAccountManagerDelegate>
	[BaseType (typeof (NSObject))]
	interface SFAuthenticationManager : ISFOAuthCoordinatorDelegate, ISFIdentityCoordinatorDelegate, ISFUserAccountManagerDelegate
	{
		// @property (nonatomic, strong) UIAlertController * _Nullable statusAlert;
		[NullAllowed, Export ("statusAlert", ArgumentSemantic.Strong)]
		UIAlertController StatusAlert { get; set; }

		// @property (nonatomic, strong) SFLoginViewController * _Nullable authViewController;
		[NullAllowed, Export ("authViewController", ArgumentSemantic.Strong)]
		SFLoginViewController AuthViewController { get; set; }

		// @property (readonly, nonatomic) BOOL authenticating;
		[Export ("authenticating")]
		bool Authenticating { get; }

		// @property (readonly, nonatomic) BOOL haveValidSession;
		[Export ("haveValidSession")]
		bool HaveValidSession { get; }

		// @property (readonly, nonatomic) BOOL logoutSettingEnabled;
		[Export ("logoutSettingEnabled")]
		bool LogoutSettingEnabled { get; }

		// +(void)setInstanceClass:(Class _Nonnull)className;
		[Static]
		[Export ("setInstanceClass:")]
		void SetInstanceClass (Class className);

		// +(instancetype _Nonnull)sharedManager;
		[Static]
		[Export ("sharedManager")]
		SFAuthenticationManager SharedManager ();

		// @property (nonatomic, strong) SFAuthenticationViewHandler * _Nonnull authViewHandler;
		[Export ("authViewHandler", ArgumentSemantic.Strong)]
		SFAuthenticationViewHandler AuthViewHandler { get; set; }

		// @property (readonly, nonatomic) SFAuthErrorHandler * _Nonnull invalidCredentialsAuthErrorHandler;
		[Export ("invalidCredentialsAuthErrorHandler")]
		SFAuthErrorHandler InvalidCredentialsAuthErrorHandler { get; }

		// @property (readonly, nonatomic) SFAuthErrorHandler * _Nonnull connectedAppVersionAuthErrorHandler;
		[Export ("connectedAppVersionAuthErrorHandler")]
		SFAuthErrorHandler ConnectedAppVersionAuthErrorHandler { get; }

		// @property (readonly, nonatomic) SFAuthErrorHandler * _Nonnull networkFailureAuthErrorHandler;
		[Export ("networkFailureAuthErrorHandler")]
		SFAuthErrorHandler NetworkFailureAuthErrorHandler { get; }

		// @property (readonly, nonatomic) SFAuthErrorHandler * _Nonnull genericAuthErrorHandler;
		[Export ("genericAuthErrorHandler")]
		SFAuthErrorHandler GenericAuthErrorHandler { get; }

		// @property (nonatomic, strong) SFAuthErrorHandlerList * _Nonnull authErrorHandlerList;
		[Export ("authErrorHandlerList", ArgumentSemantic.Strong)]
		SFAuthErrorHandlerList AuthErrorHandlerList { get; set; }

		// @property (nonatomic, strong) SFOAuthCoordinator * _Nonnull coordinator;
		[Export ("coordinator", ArgumentSemantic.Strong)]
		SFOAuthCoordinator Coordinator { get; set; }

		// @property (nonatomic, strong) SFIdentityCoordinator * _Nonnull idCoordinator;
		[Export ("idCoordinator", ArgumentSemantic.Strong)]
		SFIdentityCoordinator IdCoordinator { get; set; }

		// @property (assign, nonatomic) SFOAuthAdvancedAuthConfiguration advancedAuthConfiguration;
		[Export ("advancedAuthConfiguration", ArgumentSemantic.Assign)]
		SFOAuthAdvancedAuthConfiguration AdvancedAuthConfiguration { get; set; }

		// @property (nonatomic, strong) NSArray * _Nonnull additionalOAuthParameterKeys;
		[Export ("additionalOAuthParameterKeys", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		string [] AdditionalOAuthParameterKeys { get; set; }

		// @property (nonatomic, strong) NSDictionary * _Nonnull additionalTokenRefreshParams;
		[Export ("additionalTokenRefreshParams", ArgumentSemantic.Strong)]
		NSDictionary AdditionalTokenRefreshParams { get; set; }

		// -(void)addDelegate:(id<SFAuthenticationManagerDelegate> _Nonnull)delegate;
		[Export ("addDelegate:")]
		void AddDelegate (ISFAuthenticationManagerDelegate @delegate);

		// -(void)addDelegate:(id<SFAuthenticationManagerDelegate> _Nonnull)delegate withPriority:(SFAuthenticationManagerDelegatePriority)priority;
		[Export ("addDelegate:withPriority:")]
		void AddDelegate (ISFAuthenticationManagerDelegate @delegate, SFAuthenticationManagerDelegatePriority priority);

		// -(void)removeDelegate:(id<SFAuthenticationManagerDelegate> _Nonnull)delegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (ISFAuthenticationManagerDelegate @delegate);

		// -(BOOL)loginWithCompletion:(SFOAuthFlowSuccessCallbackBlock _Nullable)completionBlock failure:(SFOAuthFlowFailureCallbackBlock _Nullable)failureBlock;
		[Export ("loginWithCompletion:failure:")]
		bool LoginWithCompletion ([NullAllowed] SFOAuthFlowSuccessCallbackBlock completionBlock, [NullAllowed] SFOAuthFlowFailureCallbackBlock failureBlock);

		// -(BOOL)loginWithCompletion:(SFOAuthFlowSuccessCallbackBlock _Nullable)completionBlock failure:(SFOAuthFlowFailureCallbackBlock _Nullable)failureBlock account:(SFUserAccount * _Nullable)account;
		[Export ("loginWithCompletion:failure:account:")]
		bool LoginWithCompletion ([NullAllowed] SFOAuthFlowSuccessCallbackBlock completionBlock, [NullAllowed] SFOAuthFlowFailureCallbackBlock failureBlock, [NullAllowed] SFUserAccount account);

		// -(BOOL)loginWithJwtToken:(NSString * _Nonnull)jwtToken completion:(SFOAuthFlowSuccessCallbackBlock _Nullable)completionBlock failure:(SFOAuthFlowFailureCallbackBlock _Nullable)failureBlock;
		[Export ("loginWithJwtToken:completion:failure:")]
		bool LoginWithJwtToken (string jwtToken, [NullAllowed] SFOAuthFlowSuccessCallbackBlock completionBlock, [NullAllowed] SFOAuthFlowFailureCallbackBlock failureBlock);

		// -(void)logout;
		[Export ("logout")]
		void Logout ();

		// -(void)logoutUser:(SFUserAccount * _Nonnull)user;
		[Export ("logoutUser:")]
		void LogoutUser (SFUserAccount user);

		// -(void)logoutAllUsers;
		[Export ("logoutAllUsers")]
		void LogoutAllUsers ();

		// -(void)cancelAuthentication;
		[Export ("cancelAuthentication")]
		void CancelAuthentication ();

		// -(BOOL)handleAdvancedAuthenticationResponse:(NSURL * _Nonnull)appUrlResponse;
		[Export ("handleAdvancedAuthenticationResponse:")]
		bool HandleAdvancedAuthenticationResponse (NSUrl appUrlResponse);

		// -(void)dismissAuthViewControllerIfPresent;
		[Export ("dismissAuthViewControllerIfPresent")]
		void DismissAuthViewControllerIfPresent ();

		// +(void)resetSessionCookie;
		[Static]
		[Export ("resetSessionCookie")]
		void ResetSessionCookie ();

		// +(BOOL)errorIsInvalidAuthCredentials:(NSError * _Nonnull)error;
		[Static]
		[Export ("errorIsInvalidAuthCredentials:")]
		bool ErrorIsInvalidAuthCredentials (NSError error);

		// +(void)removeCookies:(NSArray<NSString *> * _Nonnull)cookieNames fromDomains:(NSArray<NSString *> * _Nonnull)domainNames;
		[Static]
		[Export ("removeCookies:fromDomains:")]
		void RemoveCookies (string [] cookieNames, string [] domainNames);

		// +(void)removeAllCookies;
		[Static]
		[Export ("removeAllCookies")]
		void RemoveAllCookies ();

		// +(void)addSidCookieForDomain:(NSString * _Nonnull)domain;
		[Static]
		[Export ("addSidCookieForDomain:")]
		void AddSidCookieForDomain (string domain);
	}

	// typedef UIViewController * _Nullable (^SFSnapshotViewControllerCreationBlock)();
	delegate UIViewController SFSnapshotViewControllerCreationBlock ();

	// typedef void (^SFSnapshotViewControllerPresentationBlock)(UIViewController * _Nonnull);
	delegate void SFSnapshotViewControllerPresentationBlock (UIViewController arg0);

	// typedef void (^SFSnapshotViewControllerDismissalBlock)(UIViewController * _Nonnull);
	delegate void SFSnapshotViewControllerDismissalBlock (UIViewController arg0);

	// @protocol SalesforceSDKManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface SalesforceSDKManagerDelegate
	{
		// @optional -(void)sdkManagerWillResignActive;
		[Export ("sdkManagerWillResignActive")]
		void SdkManagerWillResignActive ();

		// @optional -(void)sdkManagerDidBecomeActive;
		[Export ("sdkManagerDidBecomeActive")]
		void SdkManagerDidBecomeActive ();

		// @optional -(void)sdkManagerWillEnterForeground;
		[Export ("sdkManagerWillEnterForeground")]
		void SdkManagerWillEnterForeground ();

		// @optional -(void)sdkManagerDidEnterBackground;
		[Export ("sdkManagerDidEnterBackground")]
		void SdkManagerDidEnterBackground ();
	}

	// @interface SalesforceSDKManager : NSObject <SFAuthenticationManagerDelegate>
	[BaseType (typeof (NSObject))]
	interface SalesforceSDKManager : ISFAuthenticationManagerDelegate
	{
		// +(void)setInstanceClass:(Class _Nonnull)className;
		[Static]
		[Export ("setInstanceClass:")]
		void SetInstanceClass (Class className);

		// +(instancetype _Nonnull)sharedManager;
		[Static]
		[Export ("sharedManager")]
		SalesforceSDKManager SharedManager ();

		// -(NSString * _Nonnull)deviceId;
		[Export ("deviceId")]
		//[Verify (MethodToProperty)]
		string DeviceId { get; }

		// @property (nonatomic, strong) SFSDKAppConfig * _Nullable appConfig;
		[NullAllowed, Export ("appConfig", ArgumentSemantic.Strong)]
		SFSDKAppConfig AppConfig { get; set; }

		// @property (readonly, nonatomic) BOOL isLaunching;
		[Export ("isLaunching")]
		bool IsLaunching { get; }

		// @property (nonatomic, strong) NSMutableSet * _Nonnull features;
		[Export ("features", ArgumentSemantic.Strong)]
		NSMutableSet Features { get; set; }

		// @property (readonly, nonatomic) SFAppType appType;
		[Export ("appType")]
		SFAppType AppType { get; }

		// @property (copy, nonatomic) NSString * _Nullable connectedAppId;
		[NullAllowed, Export ("connectedAppId")]
		string ConnectedAppId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable connectedAppCallbackUri;
		[NullAllowed, Export ("connectedAppCallbackUri")]
		string ConnectedAppCallbackUri { get; set; }

		// @property (nonatomic, strong) NSArray<NSString *> * _Nullable authScopes;
		[NullAllowed, Export ("authScopes", ArgumentSemantic.Strong)]
		string [] AuthScopes { get; set; }

		// @property (assign, nonatomic) BOOL authenticateAtLaunch;
		[Export ("authenticateAtLaunch")]
		bool AuthenticateAtLaunch { get; set; }

		// @property (copy, nonatomic) SFSDKPostLaunchCallbackBlock _Nullable postLaunchAction;
		[NullAllowed, Export ("postLaunchAction", ArgumentSemantic.Copy)]
		SFSDKPostLaunchCallbackBlock PostLaunchAction { get; set; }

		// @property (copy, nonatomic) SFSDKLaunchErrorCallbackBlock _Nullable launchErrorAction;
		[NullAllowed, Export ("launchErrorAction", ArgumentSemantic.Copy)]
		SFSDKLaunchErrorCallbackBlock LaunchErrorAction { get; set; }

		// @property (copy, nonatomic) SFSDKLogoutCallbackBlock _Nullable postLogoutAction;
		[NullAllowed, Export ("postLogoutAction", ArgumentSemantic.Copy)]
		SFSDKLogoutCallbackBlock PostLogoutAction { get; set; }

		// @property (copy, nonatomic) SFSDKSwitchUserCallbackBlock _Nullable switchUserAction;
		[NullAllowed, Export ("switchUserAction", ArgumentSemantic.Copy)]
		SFSDKSwitchUserCallbackBlock SwitchUserAction { get; set; }

		// @property (copy, nonatomic) SFSDKAppForegroundCallbackBlock _Nullable postAppForegroundAction;
		[NullAllowed, Export ("postAppForegroundAction", ArgumentSemantic.Copy)]
		SFSDKAppForegroundCallbackBlock PostAppForegroundAction { get; set; }

		// @property (assign, nonatomic) BOOL useSnapshotView;
		[Export ("useSnapshotView")]
		bool UseSnapshotView { get; set; }

		// @property (copy, nonatomic) SFSnapshotViewControllerCreationBlock _Nullable snapshotViewControllerCreationAction;
		[NullAllowed, Export ("snapshotViewControllerCreationAction", ArgumentSemantic.Copy)]
		SFSnapshotViewControllerCreationBlock SnapshotViewControllerCreationAction { get; set; }

		// @property (copy, nonatomic) SFSnapshotViewControllerPresentationBlock _Nullable snapshotPresentationAction;
		[NullAllowed, Export ("snapshotPresentationAction", ArgumentSemantic.Copy)]
		SFSnapshotViewControllerPresentationBlock SnapshotPresentationAction { get; set; }

		// @property (copy, nonatomic) SFSnapshotViewControllerDismissalBlock _Nullable snapshotDismissalAction;
		[NullAllowed, Export ("snapshotDismissalAction", ArgumentSemantic.Copy)]
		SFSnapshotViewControllerDismissalBlock SnapshotDismissalAction { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable preferredPasscodeProvider;
		[NullAllowed, Export ("preferredPasscodeProvider")]
		string PreferredPasscodeProvider { get; set; }

		// @property (copy, nonatomic) SFSDKUserAgentCreationBlock _Nonnull userAgentString;
		[Export ("userAgentString", ArgumentSemantic.Copy)]
		SFSDKUserAgentCreationBlock UserAgentString { get; set; }

		// -(BOOL)launch;
		[Export ("launch")]
		//[Verify (MethodToProperty)]
		bool Launch ();// { get; }

		// -(void)registerAppFeature:(NSString * _Nonnull)appFeature;
		[Export ("registerAppFeature:")]
		void RegisterAppFeature (string appFeature);

		// -(void)unregisterAppFeature:(NSString * _Nonnull)appFeature;
		[Export ("unregisterAppFeature:")]
		void UnregisterAppFeature (string appFeature);

		// -(void)addDelegate:(id<SalesforceSDKManagerDelegate> _Nonnull)delegate;
		[Export ("addDelegate:")]
		void AddDelegate (SalesforceSDKManagerDelegate @delegate);

		// -(void)removeDelegate:(id<SalesforceSDKManagerDelegate> _Nonnull)delegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (SalesforceSDKManagerDelegate @delegate);

		// +(NSString * _Nonnull)launchActionsStringRepresentation:(SFSDKLaunchAction)launchActions;
		[Static]
		[Export ("launchActionsStringRepresentation:")]
		string LaunchActionsStringRepresentation (SFSDKLaunchAction launchActions);

		// +(void)setDesiredAccount:(SFUserAccount * _Nonnull)account;
		[Static]
		[Export ("setDesiredAccount:")]
		void SetDesiredAccount (SFUserAccount account);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const SFPasscodeConfigurationData SFPasscodeConfigurationDataNull;
		//[Field ("SFPasscodeConfigurationDataNull", "__Internal")]
		//SFPasscodeConfigurationData SFPasscodeConfigurationDataNull { get; }

		// extern NSString *const kSFPasscodeFlowWillBegin;
		[Field ("kSFPasscodeFlowWillBegin", "__Internal")]
		NSString kSFPasscodeFlowWillBegin { get; }

		// extern NSString *const kSFPasscodeFlowCompleted;
		[Field ("kSFPasscodeFlowCompleted", "__Internal")]
		NSString kSFPasscodeFlowCompleted { get; }
	}

	// typedef void (^SFLockScreenSuccessCallbackBlock)(SFSecurityLockoutAction);
	delegate void SFLockScreenSuccessCallbackBlock (SFSecurityLockoutAction arg0);

	// typedef void (^SFLockScreenFailureCallbackBlock)();
	delegate void SFLockScreenFailureCallbackBlock ();

	// typedef UIViewController * (^SFPasscodeViewControllerCreationBlock)(SFPasscodeControllerMode, SFPasscodeConfigurationData);
	delegate UIViewController SFPasscodeViewControllerCreationBlock (SFPasscodeControllerMode arg0, SFPasscodeConfigurationData arg1);

	// typedef void (^SFPasscodeViewControllerPresentationBlock)(UIViewController *);
	delegate void SFPasscodeViewControllerPresentationBlock (UIViewController arg0);

	// @protocol SFSecurityLockoutDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface SFSecurityLockoutDelegate
	{
		// @optional -(void)passcodeFlowWillBegin:(SFPasscodeControllerMode)mode;
		[Export ("passcodeFlowWillBegin:")]
		void PasscodeFlowWillBegin (SFPasscodeControllerMode mode);

		// @optional -(void)passcodeFlowDidComplete:(BOOL)success;
		[Export ("passcodeFlowDidComplete:")]
		void PasscodeFlowDidComplete (bool success);
	}

	// @interface SFSecurityLockout : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSecurityLockout
	{
		// +(void)addDelegate:(id<SFSecurityLockoutDelegate>)delegate;
		[Static]
		[Export ("addDelegate:")]
		void AddDelegate (SFSecurityLockoutDelegate @delegate);

		// +(void)removeDelegate:(id<SFSecurityLockoutDelegate>)delegate;
		[Static]
		[Export ("removeDelegate:")]
		void RemoveDelegate (SFSecurityLockoutDelegate @delegate);

		// +(NSUInteger)lockoutTime;
		[Static]
		[Export ("lockoutTime")]
		//[Verify (MethodToProperty)]
		nuint LockoutTime { get; }

		// +(NSInteger)passcodeLength;
		[Static]
		[Export ("passcodeLength")]
		//[Verify (MethodToProperty)]
		nint PasscodeLength { get; }

		// +(void)setPasscodeLength:(NSInteger)newPasscodeLength lockoutTime:(NSUInteger)newLockoutTime;
		[Static]
		[Export ("setPasscodeLength:lockoutTime:")]
		void SetPasscodeLength (nint newPasscodeLength, nuint newLockoutTime);

		// +(void)clearPasscodeState;
		[Static]
		[Export ("clearPasscodeState")]
		void ClearPasscodeState ();

		// +(void)setupTimer;
		[Static]
		[Export ("setupTimer")]
		void SetupTimer ();

		// +(void)removeTimer;
		[Static]
		[Export ("removeTimer")]
		void RemoveTimer ();

		// +(void)validateTimer;
		[Static]
		[Export ("validateTimer")]
		void ValidateTimer ();

		// +(BOOL)isLockoutEnabled;
		[Static]
		[Export ("isLockoutEnabled")]
		//[Verify (MethodToProperty)]
		bool IsLockoutEnabled { get; }

		// +(BOOL)inactivityExpired;
		[Static]
		[Export ("inactivityExpired")]
		//[Verify (MethodToProperty)]
		bool InactivityExpired { get; }

		// +(void)startActivityMonitoring;
		[Static]
		[Export ("startActivityMonitoring")]
		void StartActivityMonitoring ();

		// +(void)stopActivityMonitoring;
		[Static]
		[Export ("stopActivityMonitoring")]
		void StopActivityMonitoring ();

		// +(void)lock;
		[Static]
		[Export ("lock")]
		void Lock ();

		// +(void)unlock:(BOOL)success action:(SFSecurityLockoutAction)action passcodeConfig:(SFPasscodeConfigurationData)configData;
		[Static]
		[Export ("unlock:action:passcodeConfig:")]
		void Unlock (bool success, SFSecurityLockoutAction action, SFPasscodeConfigurationData configData);

		// +(void)setIsLocked:(BOOL)locked;
		[Static]
		[Export ("setIsLocked:")]
		void SetIsLocked (bool locked);

		// +(BOOL)locked;
		[Static]
		[Export ("locked")]
		//[Verify (MethodToProperty)]
		bool Locked { get; }

		// +(BOOL)isPasscodeValid;
		[Static]
		[Export ("isPasscodeValid")]
		//[Verify (MethodToProperty)]
		bool IsPasscodeValid { get; }

		// +(BOOL)isPasscodeNeeded;
		[Static]
		[Export ("isPasscodeNeeded")]
		//[Verify (MethodToProperty)]
		bool IsPasscodeNeeded { get; }

		// +(void)setCanShowPasscode:(BOOL)showPasscode;
		[Static]
		[Export ("setCanShowPasscode:")]
		void SetCanShowPasscode (bool showPasscode);

		// +(SFLockScreenSuccessCallbackBlock)lockScreenSuccessCallbackBlock;
		// +(void)setLockScreenSuccessCallbackBlock:(SFLockScreenSuccessCallbackBlock)block;
		[Static]
		[Export ("lockScreenSuccessCallbackBlock")]
		//[Verify (MethodToProperty)]
		SFLockScreenSuccessCallbackBlock LockScreenSuccessCallbackBlock { get; set; }

		// +(SFLockScreenFailureCallbackBlock)lockScreenFailureCallbackBlock;
		// +(void)setLockScreenFailureCallbackBlock:(SFLockScreenFailureCallbackBlock)block;
		[Static]
		[Export ("lockScreenFailureCallbackBlock")]
		//[Verify (MethodToProperty)]
		SFLockScreenFailureCallbackBlock LockScreenFailureCallbackBlock { get; set; }

		// +(SFPasscodeViewControllerCreationBlock)passcodeViewControllerCreationBlock;
		// +(void)setPasscodeViewControllerCreationBlock:(SFPasscodeViewControllerCreationBlock)vcBlock;
		[Static]
		[Export ("passcodeViewControllerCreationBlock")]
		//[Verify (MethodToProperty)]
		SFPasscodeViewControllerCreationBlock PasscodeViewControllerCreationBlock { get; set; }

		// +(SFPasscodeViewControllerPresentationBlock)presentPasscodeViewControllerBlock;
		[Static]
		[Export ("presentPasscodeViewControllerBlock")]
		SFPasscodeViewControllerPresentationBlock PresentPasscodeViewControllerBlock ();

		// +(void)setPresentPasscodeViewControllerBlock:(SFPasscodeViewControllerPresentationBlock)vcBlock;
		[Static]
		[Export ("setPresentPasscodeViewControllerBlock:")]
		void SetPresentPasscodeViewControllerBlock (SFPasscodeViewControllerPresentationBlock vcBlock);

		// +(SFPasscodeViewControllerPresentationBlock)dismissPasscodeViewControllerBlock;
		[Static]
		[Export ("dismissPasscodeViewControllerBlock")]
		SFPasscodeViewControllerPresentationBlock DismissPasscodeViewControllerBlock ();

		// +(void)setDismissPasscodeViewControllerBlock:(SFPasscodeViewControllerPresentationBlock)vcBlock;
		[Static]
		[Export ("setDismissPasscodeViewControllerBlock:")]
		void SetDismissPasscodeViewControllerBlock (SFPasscodeViewControllerPresentationBlock vcBlock);

		// +(void)setPasscodeViewController:(UIViewController *)vc;
		[Static]
		[Export ("setPasscodeViewController:")]
		void SetPasscodeViewController (UIViewController vc);

		// +(UIViewController *)passcodeViewController;
		[Static]
		[Export ("passcodeViewController")]
		UIViewController PasscodeViewController ();

		// +(void)setForcePasscodeDisplay:(BOOL)forceDisplay;
		[Static]
		[Export ("setForcePasscodeDisplay:")]
		void SetForcePasscodeDisplay (bool forceDisplay);

		// +(BOOL)forcePasscodeDisplay;
		[Static]
		[Export ("forcePasscodeDisplay")]
		bool ForcePasscodeDisplay ();

		// +(BOOL)validatePasscodeAtStartup;
		[Static]
		[Export ("validatePasscodeAtStartup")]
		bool ValidatePasscodeAtStartup ();
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kRemainingAttemptsKey;
		[Field ("kRemainingAttemptsKey", "__Internal")]
		NSString kRemainingAttemptsKey { get; }

		// extern const NSUInteger kMaxNumberofAttempts;
		[Field ("kMaxNumberofAttempts", "__Internal")]
		nuint kMaxNumberofAttempts { get; }
	}

	// @interface SFAbstractPasscodeViewController : UIViewController
	[BaseType (typeof (UIViewController))]
	interface SFAbstractPasscodeViewController
	{
		// @property (readonly) SFPasscodeConfigurationData configData;
		[Export ("configData")]
		SFPasscodeConfigurationData ConfigData { get; }

		// @property (readonly) NSInteger minPasscodeLength;
		[Export ("minPasscodeLength")]
		nint MinPasscodeLength { get; }

		// @property (readonly) SFPasscodeControllerMode mode;
		[Export ("mode")]
		SFPasscodeControllerMode Mode { get; }

		// @property (readonly) NSInteger remainingAttempts;
		[Export ("remainingAttempts")]
		nint RemainingAttempts { get; }

		// -(id)initWithMode:(SFPasscodeControllerMode)mode passcodeConfig:(SFPasscodeConfigurationData)configData;
		[Export ("initWithMode:passcodeConfig:")]
		IntPtr Constructor (SFPasscodeControllerMode mode, SFPasscodeConfigurationData configData);

		// -(void)createPasscodeConfirmed:(NSString *)newPasscode;
		[Export ("createPasscodeConfirmed:")]
		void CreatePasscodeConfirmed (string newPasscode);

		// -(void)validatePasscodeConfirmed:(NSString *)validPasscode;
		[Export ("validatePasscodeConfirmed:")]
		void ValidatePasscodeConfirmed (string validPasscode);

		// -(BOOL)decrementPasscodeAttempts;
		[Export ("decrementPasscodeAttempts")]
		//[Verify (MethodToProperty)]
		bool DecrementPasscodeAttempts ();// { get; }

		// -(void)validatePasscodeFailed;
		[Export ("validatePasscodeFailed")]
		void ValidatePasscodeFailed ();

		// -(BOOL)canShowTouchId;
		[Export ("canShowTouchId")]
		//[Verify (MethodToProperty)]
		bool CanShowTouchId { get; }

		// -(void)showTouchId;
		[Export ("showTouchId")]
		void ShowTouchId ();
	}

	// @interface SFApplication : UIApplication
	[BaseType (typeof (UIApplication))]
	interface SFApplication
	{
		// @property (readonly, atomic) NSDate * lastEventDate;
		[Export ("lastEventDate")]
		NSDate LastEventDate { get; }
	}

	// @interface SFApplicationHelper : NSObject
	[BaseType (typeof (NSObject))]
	interface SFApplicationHelper
	{
		// +(UIApplication *)sharedApplication;
		[Static]
		[Export ("sharedApplication")]
		//[Verify (MethodToProperty)]
		UIApplication SharedApplication { get; }

		// +(BOOL)openURL:(NSURL *)url;
		[Static]
		[Export ("openURL:")]
		bool OpenURL (NSUrl url);
	}

	// typedef void (^SFAuthViewDisplayBlock)(SFAuthenticationManager *, WKWebView *);
	delegate void SFAuthViewDisplayBlock (SFAuthenticationManager arg0, WKWebView arg1);

	// typedef void (^SFAuthViewDismissBlock)(SFAuthenticationManager *);
	delegate void SFAuthViewDismissBlock (SFAuthenticationManager arg0);

	// @interface SFAuthenticationViewHandler : NSObject
	[BaseType (typeof (NSObject))]
	interface SFAuthenticationViewHandler
	{
		// @property (copy, nonatomic) SFAuthViewDisplayBlock authViewDisplayBlock;
		[Export ("authViewDisplayBlock", ArgumentSemantic.Copy)]
		SFAuthViewDisplayBlock AuthViewDisplayBlock { get; set; }

		// @property (copy, nonatomic) SFAuthViewDismissBlock authViewDismissBlock;
		[Export ("authViewDismissBlock", ArgumentSemantic.Copy)]
		SFAuthViewDismissBlock AuthViewDismissBlock { get; set; }

		// -(id)initWithDisplayBlock:(SFAuthViewDisplayBlock)displayBlock dismissBlock:(SFAuthViewDismissBlock)dismissBlock;
		[Export ("initWithDisplayBlock:dismissBlock:")]
		IntPtr Constructor (SFAuthViewDisplayBlock displayBlock, SFAuthViewDismissBlock dismissBlock);
	}

	// typedef BOOL (^SFAuthErrorHandlerEvalBlock)(NSError *, SFOAuthInfo *);
	delegate bool SFAuthErrorHandlerEvalBlock (NSError arg0, SFOAuthInfo arg1);

	// @interface SFAuthErrorHandler : NSObject
	[BaseType (typeof (NSObject))]
	interface SFAuthErrorHandler
	{
		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) SFAuthErrorHandlerEvalBlock evalBlock;
		[Export ("evalBlock")]
		SFAuthErrorHandlerEvalBlock EvalBlock { get; }

		// -(id)initWithName:(NSString *)name evalBlock:(SFAuthErrorHandlerEvalBlock)evalBlock;
		[Export ("initWithName:evalBlock:")]
		IntPtr Constructor (string name, SFAuthErrorHandlerEvalBlock evalBlock);
	}

	// @interface SFAuthErrorHandlerList : NSObject
	[BaseType (typeof (NSObject))]
	interface SFAuthErrorHandlerList
	{
		// @property (readonly, nonatomic) NSArray * authHandlerArray;
		[Export ("authHandlerArray")]
		//[Verify (StronglyTypedNSArray)]
		SFAuthErrorHandler [] AuthHandlerArray { get; }

		// -(void)addAuthErrorHandler:(SFAuthErrorHandler *)errorHandler;
		[Export ("addAuthErrorHandler:")]
		void AddAuthErrorHandler (SFAuthErrorHandler errorHandler);

		// -(void)addAuthErrorHandler:(SFAuthErrorHandler *)errorHandler atIndex:(NSUInteger)index;
		[Export ("addAuthErrorHandler:atIndex:")]
		void AddAuthErrorHandler (SFAuthErrorHandler errorHandler, nuint index);

		// -(void)removeAuthErrorHandlerWithName:(NSString *)errorHandlerName;
		[Export ("removeAuthErrorHandlerWithName:")]
		void RemoveAuthErrorHandlerWithName (string errorHandlerName);

		// -(void)removeAuthErrorHandler:(SFAuthErrorHandler *)errorHandler;
		[Export ("removeAuthErrorHandler:")]
		void RemoveAuthErrorHandler (SFAuthErrorHandler errorHandler);

		// -(BOOL)authErrorHandlerInList:(SFAuthErrorHandler *)errorHandler;
		[Export ("authErrorHandlerInList:")]
		bool AuthErrorHandlerInList (SFAuthErrorHandler errorHandler);
	}

	// @interface SFCommunityData : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	interface SFCommunityData : INSCoding
	{
		// @property (nonatomic, strong) NSString * entityId;
		[Export ("entityId", ArgumentSemantic.Strong)]
		string EntityId { get; set; }

		// @property (nonatomic, strong) NSString * name;
		[Export ("name", ArgumentSemantic.Strong)]
		string Name { get; set; }

		// @property (nonatomic, strong) NSString * descriptionText;
		[Export ("descriptionText", ArgumentSemantic.Strong)]
		string DescriptionText { get; set; }

		// @property (nonatomic, strong) NSURL * siteUrl;
		[Export ("siteUrl", ArgumentSemantic.Strong)]
		NSUrl SiteUrl { get; set; }

		// @property (nonatomic, strong) NSURL * url;
		[Export ("url", ArgumentSemantic.Strong)]
		NSUrl Url { get; set; }

		// @property (nonatomic, strong) NSURL * urlPathPrefix;
		[Export ("urlPathPrefix", ArgumentSemantic.Strong)]
		NSUrl UrlPathPrefix { get; set; }

		// @property (nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { get; set; }

		// @property (nonatomic) BOOL invitationsEnabled;
		[Export ("invitationsEnabled")]
		bool InvitationsEnabled { get; set; }

		// @property (nonatomic) BOOL sendWelcomeEmail;
		[Export ("sendWelcomeEmail")]
		bool SendWelcomeEmail { get; set; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const size_t SFCryptChunksCipherBlockSize;
		[Field ("SFCryptChunksCipherBlockSize", "__Internal")]
		nint SFCryptChunksCipherBlockSize { get; }

		// extern const uint32_t SFCryptChunksCipherAlgorithm;
		[Field ("SFCryptChunksCipherAlgorithm", "__Internal")]
		int SFCryptChunksCipherAlgorithm { get; }

		// extern const size_t SFCryptChunksCipherKeySize;
		[Field ("SFCryptChunksCipherKeySize", "__Internal")]
		nint SFCryptChunksCipherKeySize { get; }

		// extern const uint32_t SFCryptChunksCipherOptions;
		[Field ("SFCryptChunksCipherOptions", "__Internal")]
		int SFCryptChunksCipherOptions { get; }
	}

	// @protocol SFCryptChunksDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface ISFCryptChunksDelegate
	{
		// @required -(void)cryptChunk:(SFCryptChunks * _Nonnull)cryptChunks chunkResult:(uint8_t * _Nonnull)buffer bufferLen:(size_t)len;
		[Abstract]
		[Export ("cryptChunk:chunkResult:bufferLen:")]
		unsafe void ChunkResult (SFCryptChunks cryptChunks, byte buffer, nuint len);
	}

	// @interface SFCryptChunks : NSObject
	[BaseType (typeof (NSObject))]
	interface SFCryptChunks
	{
		// -(instancetype _Nonnull)initForEncryptionWithKey:(NSData * _Nonnull)key initializationVector:(NSData * _Nullable)iv;
		[Static]
		[Export ("initForEncryptionWithKey:initializationVector:")]
		IntPtr CreateForEncryption (NSData key, [NullAllowed] NSData iv);

		// -(instancetype _Nonnull)initForDecryptionWithKey:(NSData * _Nonnull)key initializationVector:(NSData * _Nullable)iv;
		[Static]
		[Export ("initForDecryptionWithKey:initializationVector:")]
		IntPtr CreateForDecryption (NSData key, [NullAllowed] NSData iv);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ISFCryptChunksDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SFCryptChunksDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)cryptBuffer:(const uint8_t * _Nonnull)buffer bufferLen:(size_t)len;
		[Export ("cryptBuffer:bufferLen:")]
		unsafe void CryptBuffer (byte buffer, nuint len);

		// @property (readonly, assign, nonatomic) BOOL cryptFinalized;
		[Export ("cryptFinalized")]
		bool CryptFinalized { get; }

		// -(void)finalizeCrypt;
		[Export ("finalizeCrypt")]
		void FinalizeCrypt ();
	}

	// @interface SFCrypto : NSObject
	[BaseType (typeof (NSObject))]
	interface SFCrypto
	{
		// @property (copy, nonatomic) NSString * file;
		[Export ("file")]
		string File { get; set; }

		// @property (readonly, nonatomic) SFCryptoMode mode;
		[Export ("mode")]
		SFCryptoMode Mode { get; }

		// -(id)initWithOperation:(SFCryptoOperation)operation key:(NSData *)key mode:(SFCryptoMode)mode;
		[Export ("initWithOperation:key:mode:")]
		IntPtr Constructor (SFCryptoOperation operation, NSData key, SFCryptoMode mode);

		// -(id)initWithOperation:(SFCryptoOperation)operation key:(NSData *)key iv:(NSData *)iv mode:(SFCryptoMode)mode;
		[Export ("initWithOperation:key:iv:mode:")]
		IntPtr Constructor (SFCryptoOperation operation, NSData key, NSData iv, SFCryptoMode mode);

		// -(void)cryptData:(NSData *)inData;
		[Export ("cryptData:")]
		void CryptData (NSData inData);

		// -(NSData *)decryptDataInMemory:(NSData *)data;
		[Export ("decryptDataInMemory:")]
		NSData DecryptDataInMemory (NSData data);

		// -(NSData *)encryptDataInMemory:(NSData *)data;
		[Export ("encryptDataInMemory:")]
		NSData EncryptDataInMemory (NSData data);

		// -(BOOL)finalizeCipher;
		[Export ("finalizeCipher")]
		//[Verify (MethodToProperty)]
		bool FinalizeCipher ();// { get; }

		// -(BOOL)decrypt:(NSString *)inputFile to:(NSString *)outputFile;
		[Export ("decrypt:to:")]
		bool Decrypt (string inputFile, string outputFile);

		// +(NSData *)secretWithKey:(NSString *)key;
		[Static]
		[Export ("secretWithKey:")]
		NSData SecretWithKey (string key);

		// +(NSString *)baseAppIdentifier;
		[Static]
		[Export ("baseAppIdentifier")]
		//[Verify (MethodToProperty)]
		string BaseAppIdentifier { get; }

		// +(BOOL)baseAppIdentifierIsConfigured;
		[Static]
		[Export ("baseAppIdentifierIsConfigured")]
		//[Verify (MethodToProperty)]
		bool BaseAppIdentifierIsConfigured { get; }

		// +(BOOL)baseAppIdentifierConfiguredThisLaunch;
		[Static]
		[Export ("baseAppIdentifierConfiguredThisLaunch")]
		//[Verify (MethodToProperty)]
		bool BaseAppIdentifierConfiguredThisLaunch { get; }

		// +(BOOL)hasInitializationVector;
		[Static]
		[Export ("hasInitializationVector")]
		//[Verify (MethodToProperty)]
		bool HasInitializationVector { get; }
	}

	// @interface SFDecryptStream : NSInputStream <SFCryptChunksDelegate>
	[BaseType (typeof (NSInputStream))]
	interface SFDecryptStream : ISFCryptChunksDelegate
	{
		// -(void)setupWithKey:(NSData * _Nonnull)key andInitializationVector:(NSData * _Nullable)iv;
		[Export ("setupWithKey:andInitializationVector:")]
		void SetupWithKey (NSData key, [NullAllowed] NSData iv);
	}

	// @interface SFDefaultUserManagementDetailViewController : UIViewController
	[BaseType (typeof (UIViewController))]
	interface SFDefaultUserManagementDetailViewController
	{
		// -(id)initWithUser:(SFUserAccount *)user;
		[Export ("initWithUser:")]
		IntPtr Constructor (SFUserAccount user);
	}

	// @interface SFDefaultUserManagementListViewController : UITableViewController
	[BaseType (typeof (UITableViewController))]
	interface SFDefaultUserManagementListViewController
	{
	}

	// typedef void (^SFUserManagementCompletionBlock)(SFUserManagementAction);
	delegate void SFUserManagementCompletionBlock (SFUserManagementAction arg0);

	// @interface SFDefaultUserManagementViewController : UINavigationController
	[BaseType (typeof (UINavigationController))]
	interface SFDefaultUserManagementViewController
	{
		// -(id)initWithCompletionBlock:(SFUserManagementCompletionBlock)completionBlock;
		[Export ("initWithCompletionBlock:")]
		IntPtr Constructor (SFUserManagementCompletionBlock completionBlock);
	}

	// @interface SFDirectoryManager : NSObject
	[BaseType (typeof (NSObject))]
	interface SFDirectoryManager
	{
		// +(instancetype)sharedManager;
		[Static]
		[Export ("sharedManager")]
		SFDirectoryManager SharedManager ();

		// +(BOOL)ensureDirectoryExists:(NSString *)directory error:(NSError **)error;
		[Static]
		[Export ("ensureDirectoryExists:error:")]
		bool EnsureDirectoryExists (string directory, out NSError error);

		// +(NSString *)safeStringForDiskRepresentation:(NSString *)candidate;
		[Static]
		[Export ("safeStringForDiskRepresentation:")]
		string SafeStringForDiskRepresentation (string candidate);

		// -(NSString *)directoryForOrg:(NSString *)orgId user:(NSString *)userId community:(NSString *)communityId type:(NSSearchPathDirectory)type components:(NSArray *)components;
		[Export ("directoryForOrg:user:community:type:components:")]
		//[Verify (StronglyTypedNSArray)]
		string DirectoryForOrg (string orgId, string userId, string communityId, NSSearchPathDirectory type, string [] components);

		// -(NSString *)directoryForUser:(SFUserAccount *)user scope:(SFUserAccountScope)scope type:(NSSearchPathDirectory)type components:(NSArray *)components;
		[Export ("directoryForUser:scope:type:components:")]
		//[Verify (StronglyTypedNSArray)]
		string DirectoryForUser (SFUserAccount user, SFUserAccountScope scope, NSSearchPathDirectory type, string [] components);

		// -(NSString *)directoryForUser:(SFUserAccount *)account type:(NSSearchPathDirectory)type components:(NSArray *)components;
		[Export ("directoryForUser:type:components:")]
		//[Verify (StronglyTypedNSArray)]
		string DirectoryForUser (SFUserAccount account, NSSearchPathDirectory type, string [] components);

		// -(NSString *)directoryOfCurrentUserForType:(NSSearchPathDirectory)type components:(NSArray *)components;
		[Export ("directoryOfCurrentUserForType:components:")]
		//[Verify (StronglyTypedNSArray)]
		string DirectoryOfCurrentUserForType (NSSearchPathDirectory type, string [] components);

		// -(NSString *)globalDirectoryOfType:(NSSearchPathDirectory)type components:(NSArray *)components;
		[Export ("globalDirectoryOfType:components:")]
		//[Verify (StronglyTypedNSArray)]
		string GlobalDirectoryOfType (NSSearchPathDirectory type, string [] components);
	}

	// @interface SFEncryptionKey : NSObject <NSCoding, NSCopying>
	[BaseType (typeof (NSObject))]
	interface SFEncryptionKey : INSCoding, INSCopying
	{
		// -(id)initWithData:(NSData *)keyData initializationVector:(NSData *)iv;
		[Export ("initWithData:initializationVector:")]
		IntPtr Constructor (NSData keyData, NSData iv);

		// @property (copy, nonatomic) NSData * key;
		[Export ("key", ArgumentSemantic.Copy)]
		NSData Key { get; set; }

		// @property (copy, nonatomic) NSData * initializationVector;
		[Export ("initializationVector", ArgumentSemantic.Copy)]
		NSData InitializationVector { get; set; }

		// @property (readonly, nonatomic) NSString * keyAsString;
		[Export ("keyAsString")]
		string KeyAsString { get; }

		// @property (readonly, nonatomic) NSString * initializationVectorAsString;
		[Export ("initializationVectorAsString")]
		string InitializationVectorAsString { get; }
	}

	// @interface SFEncryptStream : NSOutputStream <SFCryptChunksDelegate>
	[BaseType (typeof (NSOutputStream))]
	interface SFEncryptStream : ISFCryptChunksDelegate
	{
		// -(void)setupWithKey:(NSData * _Nonnull)key andInitializationVector:(NSData * _Nullable)iv;
		[Export ("setupWithKey:andInitializationVector:")]
		void SetupWithKey (NSData key, [NullAllowed] NSData iv);
	}

	// @interface SFFileProtectionHelper : NSObject
	[BaseType (typeof (NSObject))]
	interface SFFileProtectionHelper
	{
		// @property (nonatomic, strong) NSString * defaultNSFileProtectionMode;
		[Export ("defaultNSFileProtectionMode", ArgumentSemantic.Strong)]
		string DefaultNSFileProtectionMode { get; set; }

		// @property (readonly, nonatomic) NSDictionary * pathsToFileProtection;
		[Export ("pathsToFileProtection")]
		NSDictionary PathsToFileProtection { get; }

		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		SFFileProtectionHelper SharedInstance ();

		// +(NSString *)fileProtectionForPath:(NSString *)path;
		[Static]
		[Export ("fileProtectionForPath:")]
		string FileProtectionForPath (string path);

		// -(void)addProtection:(NSString *)fileProtection forPath:(NSString *)path;
		[Export ("addProtection:forPath:")]
		void AddProtection (string fileProtection, string path);
	}

	// @interface SFKeyStoreKey : NSObject <NSCoding, NSCopying>
	[BaseType (typeof (NSObject))]
	interface SFKeyStoreKey : INSCoding, INSCopying
	{
		// -(id)initWithKey:(SFEncryptionKey *)key type:(SFKeyStoreKeyType)keyType;
		[Export ("initWithKey:type:")]
		IntPtr Constructor (SFEncryptionKey key, SFKeyStoreKeyType keyType);

		// @property (nonatomic, strong) SFEncryptionKey * encryptionKey;
		[Export ("encryptionKey", ArgumentSemantic.Strong)]
		SFEncryptionKey EncryptionKey { get; set; }

		// @property (assign, nonatomic) SFKeyStoreKeyType keyType;
		[Export ("keyType", ArgumentSemantic.Assign)]
		SFKeyStoreKeyType KeyType { get; set; }
	}

	// @interface SFKeyStore : NSObject
	[BaseType (typeof (NSObject))]
	interface SFKeyStore
	{
		// @property (copy, nonatomic) SFKeyStoreKey * keyStoreKey;
		[Export ("keyStoreKey", ArgumentSemantic.Copy)]
		SFKeyStoreKey KeyStoreKey { get; set; }

		// @property (nonatomic, strong) NSDictionary * keyStoreDictionary;
		[Export ("keyStoreDictionary", ArgumentSemantic.Strong)]
		NSDictionary KeyStoreDictionary { get; set; }

		// @property (readonly, nonatomic) BOOL keyStoreAvailable;
		[Export ("keyStoreAvailable")]
		bool KeyStoreAvailable { get; }

		// @property (readonly, nonatomic) BOOL keyStoreEnabled;
		[Export ("keyStoreEnabled")]
		bool KeyStoreEnabled { get; }

		// -(NSString *)keyLabelForString:(NSString *)baseKeyLabel;
		[Export ("keyLabelForString:")]
		string KeyLabelForString (string baseKeyLabel);
	}

	// @interface SFGeneratedKeyStore : SFKeyStore
	[BaseType (typeof (SFKeyStore))]
	interface SFGeneratedKeyStore
	{
	}

	// @interface SFIdentityData : NSObject <NSSecureCoding>
	[BaseType (typeof (NSObject))]
	interface SFIdentityData : INSSecureCoding
	{
		// @property (readonly, nonatomic, strong) NSDictionary * _Nonnull dictRepresentation;
		[Export ("dictRepresentation", ArgumentSemantic.Strong)]
		NSDictionary DictRepresentation { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull idUrl;
		[Export ("idUrl", ArgumentSemantic.Strong)]
		NSUrl IdUrl { get; }

		// @property (readonly) BOOL assertedUser;
		[Export ("assertedUser")]
		bool AssertedUser { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull userId;
		[Export ("userId", ArgumentSemantic.Strong)]
		string UserId { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull orgId;
		[Export ("orgId", ArgumentSemantic.Strong)]
		string OrgId { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull username;
		[Export ("username", ArgumentSemantic.Strong)]
		string Username { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull nickname;
		[Export ("nickname", ArgumentSemantic.Strong)]
		string Nickname { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull displayName;
		[Export ("displayName", ArgumentSemantic.Strong)]
		string DisplayName { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull email;
		[Export ("email", ArgumentSemantic.Strong)]
		string Email { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull firstName;
		[Export ("firstName", ArgumentSemantic.Strong)]
		string FirstName { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull lastName;
		[Export ("lastName", ArgumentSemantic.Strong)]
		string LastName { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull pictureUrl;
		[Export ("pictureUrl", ArgumentSemantic.Strong)]
		NSUrl PictureUrl { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nullable thumbnailUrl;
		[NullAllowed, Export ("thumbnailUrl", ArgumentSemantic.Strong)]
		NSUrl ThumbnailUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable enterpriseSoapUrl;
		[NullAllowed, Export ("enterpriseSoapUrl", ArgumentSemantic.Strong)]
		string EnterpriseSoapUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable metadataSoapUrl;
		[NullAllowed, Export ("metadataSoapUrl", ArgumentSemantic.Strong)]
		string MetadataSoapUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable partnerSoapUrl;
		[NullAllowed, Export ("partnerSoapUrl", ArgumentSemantic.Strong)]
		string PartnerSoapUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable restUrl;
		[NullAllowed, Export ("restUrl", ArgumentSemantic.Strong)]
		string RestUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable restSObjectsUrl;
		[NullAllowed, Export ("restSObjectsUrl", ArgumentSemantic.Strong)]
		string RestSObjectsUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable restSearchUrl;
		[NullAllowed, Export ("restSearchUrl", ArgumentSemantic.Strong)]
		string RestSearchUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable restQueryUrl;
		[NullAllowed, Export ("restQueryUrl", ArgumentSemantic.Strong)]
		string RestQueryUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable restRecentUrl;
		[NullAllowed, Export ("restRecentUrl", ArgumentSemantic.Strong)]
		string RestRecentUrl { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nullable profileUrl;
		[NullAllowed, Export ("profileUrl", ArgumentSemantic.Strong)]
		NSUrl ProfileUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable chatterFeedsUrl;
		[NullAllowed, Export ("chatterFeedsUrl", ArgumentSemantic.Strong)]
		string ChatterFeedsUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable chatterGroupsUrl;
		[NullAllowed, Export ("chatterGroupsUrl", ArgumentSemantic.Strong)]
		string ChatterGroupsUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable chatterUsersUrl;
		[NullAllowed, Export ("chatterUsersUrl", ArgumentSemantic.Strong)]
		string ChatterUsersUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable chatterFeedItemsUrl;
		[NullAllowed, Export ("chatterFeedItemsUrl", ArgumentSemantic.Strong)]
		string ChatterFeedItemsUrl { get; }

		// @property (readonly) BOOL isActive;
		[Export ("isActive")]
		bool IsActive { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull userType;
		[Export ("userType", ArgumentSemantic.Strong)]
		string UserType { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull language;
		[Export ("language", ArgumentSemantic.Strong)]
		string Language { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull locale;
		[Export ("locale", ArgumentSemantic.Strong)]
		string Locale { get; }

		// @property (readonly) int utcOffset;
		[Export ("utcOffset")]
		int UtcOffset { get; }

		// @property (readonly) BOOL mobilePoliciesConfigured;
		[Export ("mobilePoliciesConfigured")]
		bool MobilePoliciesConfigured { get; }

		// @property (readonly) int mobileAppPinLength;
		[Export ("mobileAppPinLength")]
		int MobileAppPinLength { get; }

		// @property (readonly) int mobileAppScreenLockTimeout;
		[Export ("mobileAppScreenLockTimeout")]
		int MobileAppScreenLockTimeout { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * _Nullable customAttributes;
		[NullAllowed, Export ("customAttributes", ArgumentSemantic.Strong)]
		NSDictionary CustomAttributes { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * _Nullable customPermissions;
		[NullAllowed, Export ("customPermissions", ArgumentSemantic.Strong)]
		NSDictionary CustomPermissions { get; }

		// @property (readonly, nonatomic, strong) NSDate * _Nonnull lastModifiedDate;
		[Export ("lastModifiedDate", ArgumentSemantic.Strong)]
		NSDate LastModifiedDate { get; }

		// -(instancetype _Nonnull)initWithJsonDict:(NSDictionary * _Nonnull)jsonDict;
		[Export ("initWithJsonDict:")]
		IntPtr Constructor (NSDictionary jsonDict);
	}

	// @interface SFInactivityTimerCenter : NSObject
	[BaseType (typeof (NSObject))]
	interface SFInactivityTimerCenter
	{
		// +(void)registerTimer:(NSString *)timerName target:(id)target selector:(SEL)aSelector timerInterval:(NSTimeInterval)interval;
		[Static]
		[Export ("registerTimer:target:selector:timerInterval:")]
		void RegisterTimer (string timerName, NSObject target, Selector aSelector, double interval);

		// +(void)removeTimer:(NSString *)timerName;
		[Static]
		[Export ("removeTimer:")]
		void RemoveTimer (string timerName);

		// +(void)removeAllTimers;
		[Static]
		[Export ("removeAllTimers")]
		void RemoveAllTimers ();

		// +(void)updateActivityTimestamp;
		[Static]
		[Export ("updateActivityTimestamp")]
		void UpdateActivityTimestamp ();

		// +(void)updateActivityTimestampTo:(NSDate *)date;
		[Static]
		[Export ("updateActivityTimestampTo:")]
		void UpdateActivityTimestampTo (NSDate date);

		// +(NSDate *)lastActivityTimestamp;
		[Static]
		[Export ("lastActivityTimestamp")]
		//[Verify (MethodToProperty)]
		NSDate LastActivityTimestamp { get; }

		// +(void)saveActivityTimestamp;
		[Static]
		[Export ("saveActivityTimestamp")]
		void SaveActivityTimestamp ();
	}

	// @interface SFSDKInstrumentationPostExecutionData : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKInstrumentationPostExecutionData
	{
		// @property (copy, nonatomic) NSString * selectorName;
		[Export ("selectorName")]
		string SelectorName { get; set; }

		// @property (assign, nonatomic) BOOL isInstanceMethod;
		[Export ("isInstanceMethod")]
		bool IsInstanceMethod { get; set; }

		// @property (nonatomic, strong) NSDate * executionStartDate;
		[Export ("executionStartDate", ArgumentSemantic.Strong)]
		NSDate ExecutionStartDate { get; set; }

		// @property (nonatomic, strong) NSDate * executionEndDate;
		[Export ("executionEndDate", ArgumentSemantic.Strong)]
		NSDate ExecutionEndDate { get; set; }

		// @property (assign, nonatomic) NSTimeInterval executionTime;
		[Export ("executionTime")]
		double ExecutionTime { get; set; }
	}

	// typedef void (^SFMethodInterceptorInvocationCallback)(NSInvocation *);
	delegate void SFMethodInterceptorInvocationCallback (NSInvocation arg0);

	// typedef void (^SFMethodInterceptorInvocationAfterCallback)(NSInvocation *, SFSDKInstrumentationPostExecutionData *);
	delegate void SFMethodInterceptorInvocationAfterCallback (NSInvocation arg0, SFSDKInstrumentationPostExecutionData arg1);

	// @interface SFMethodInterceptor : NSObject
	[BaseType (typeof (NSObject))]
	interface SFMethodInterceptor
	{
		// @property (nonatomic, strong) Class classToIntercept;
		[Export ("classToIntercept", ArgumentSemantic.Strong)]
		Class ClassToIntercept { get; set; }

		// @property (nonatomic) SEL selectorToIntercept;
		[Export ("selectorToIntercept", ArgumentSemantic.Assign)]
		Selector SelectorToIntercept { get; set; }

		// @property (nonatomic) BOOL instanceMethod;
		[Export ("instanceMethod")]
		bool InstanceMethod { get; set; }

		// @property (copy, nonatomic) SFMethodInterceptorInvocationCallback targetBeforeBlock;
		[Export ("targetBeforeBlock", ArgumentSemantic.Copy)]
		SFMethodInterceptorInvocationCallback TargetBeforeBlock { get; set; }

		// @property (copy, nonatomic) SFMethodInterceptorInvocationCallback targetReplaceBlock;
		[Export ("targetReplaceBlock", ArgumentSemantic.Copy)]
		SFMethodInterceptorInvocationCallback TargetReplaceBlock { get; set; }

		// @property (copy, nonatomic) SFMethodInterceptorInvocationAfterCallback targetAfterBlock;
		[Export ("targetAfterBlock", ArgumentSemantic.Copy)]
		SFMethodInterceptorInvocationAfterCallback TargetAfterBlock { get; set; }

		// @property (nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { get; set; }
	}

	// typedef BOOL (^SFInstrumentationSelectorFilter)(SEL, BOOL);
	delegate bool SFInstrumentationSelectorFilter (Selector arg0, bool arg1);

	// @interface SFInstrumentation : NSObject
	[BaseType (typeof (NSObject))]
	interface SFInstrumentation
	{
		// @property (nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { get; set; }

		// +(instancetype)instrumentationForClass:(Class)clazz;
		[Static]
		[Export ("instrumentationForClass:")]
		SFInstrumentation InstrumentationForClass (Class clazz);

		// +(instancetype)instrumentationForClassWithName:(NSString *)className;
		[Static]
		[Export ("instrumentationForClassWithName:")]
		SFInstrumentation InstrumentationForClassWithName (string className);

		// -(SFMethodInterceptor *)interceptorForSelector:(SEL)selector isInstanceSelector:(BOOL)isInstanceSelector;
		[Export ("interceptorForSelector:isInstanceSelector:")]
		SFMethodInterceptor InterceptorForSelector (Selector selector, bool isInstanceSelector);

		// -(void)interceptInstanceMethod:(SEL)selector beforeBlock:(SFMethodInterceptorInvocationCallback)before afterBlock:(SFMethodInterceptorInvocationAfterCallback)after;
		[Export ("interceptInstanceMethod:beforeBlock:afterBlock:")]
		void InterceptInstanceMethod (Selector selector, SFMethodInterceptorInvocationCallback before, SFMethodInterceptorInvocationAfterCallback after);

		// -(void)interceptInstanceMethod:(SEL)selector replaceWithInvocationBlock:(SFMethodInterceptorInvocationCallback)replace;
		[Export ("interceptInstanceMethod:replaceWithInvocationBlock:")]
		void InterceptInstanceMethod (Selector selector, SFMethodInterceptorInvocationCallback replace);

		// -(void)interceptClassMethod:(SEL)selector beforeBlock:(SFMethodInterceptorInvocationCallback)before afterBlock:(SFMethodInterceptorInvocationAfterCallback)after;
		[Export ("interceptClassMethod:beforeBlock:afterBlock:")]
		void InterceptClassMethod (Selector selector, SFMethodInterceptorInvocationCallback before, SFMethodInterceptorInvocationAfterCallback after);

		// -(void)interceptClassMethod:(SEL)selector replaceWithInvocationBlock:(SFMethodInterceptorInvocationCallback)replace;
		[Export ("interceptClassMethod:replaceWithInvocationBlock:")]
		void InterceptClassMethod (Selector selector, SFMethodInterceptorInvocationCallback replace);

		// -(void)instrumentForTiming:(SFInstrumentationSelectorFilter)selectorFilter afterBlock:(SFMethodInterceptorInvocationAfterCallback)after;
		[Export ("instrumentForTiming:afterBlock:")]
		void InstrumentForTiming (SFInstrumentationSelectorFilter selectorFilter, SFMethodInterceptorInvocationAfterCallback after);

		// -(void)instrumentForTiming:(SFInstrumentationSelectorFilter)selectorFilter inheritanceLevels:(NSUInteger)numInheritanceLevels afterBlock:(SFMethodInterceptorInvocationAfterCallback)after;
		[Export ("instrumentForTiming:inheritanceLevels:afterBlock:")]
		void InstrumentForTiming (SFInstrumentationSelectorFilter selectorFilter, nuint numInheritanceLevels, SFMethodInterceptorInvocationAfterCallback after);

		// -(void)loadInstructions:(NSArray *)instructions completion:(dispatch_block_t)completion;
		[Export ("loadInstructions:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void LoadInstructions (NSDictionary [] instructions, Action completion);

		// -(void)startMeasure;
		[Export ("startMeasure")]
		void StartMeasure ();

		// -(void)stopMeasure;
		[Export ("stopMeasure")]
		void StopMeasure ();
	}

	// @interface SFJsonUtils : NSObject
	[BaseType (typeof (NSObject))]
	interface SFJsonUtils
	{
		// +(NSError *)lastError;
		[Static]
		[Export ("lastError")]
		//[Verify (MethodToProperty)]
		NSError LastError { get; }

		// +(NSString *)JSONRepresentation:(id)object;
		[Static]
		[Export ("JSONRepresentation:")]
		string JSONRepresentation (NSObject @object);

		// +(NSString *)JSONRepresentation:(id)object options:(NSJSONWritingOptions)options;
		[Static]
		[Export ("JSONRepresentation:options:")]
		string JSONRepresentation (NSObject @object, NSJsonWritingOptions options);

		// +(NSData *)JSONDataRepresentation:(id)obj;
		[Static]
		[Export ("JSONDataRepresentation:")]
		NSData JSONDataRepresentation (NSObject obj);

		// +(NSData *)JSONDataRepresentation:(id)obj options:(NSJSONWritingOptions)options;
		[Static]
		[Export ("JSONDataRepresentation:options:")]
		NSData JSONDataRepresentation (NSObject obj, NSJsonWritingOptions options);

		// +(id)objectFromJSONString:(NSString *)jsonString;
		[Static]
		[Export ("objectFromJSONString:")]
		NSObject ObjectFromJSONString (string jsonString);

		// +(id)objectFromJSONData:(NSData *)jsonData;
		[Static]
		[Export ("objectFromJSONData:")]
		NSObject ObjectFromJSONData (NSData jsonData);

		// +(id)projectIntoJson:(NSDictionary *)jsonObj path:(NSString *)path;
		[Static]
		[Export ("projectIntoJson:path:")]
		NSObject ProjectIntoJson (NSDictionary jsonObj, string path);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kSFKeychainItemExceptionType;
		[Field ("kSFKeychainItemExceptionType", "__Internal")]
		NSString kSFKeychainItemExceptionType { get; }

		// extern NSString *const kSFKeychainItemExceptionErrorCodeKey;
		[Field ("kSFKeychainItemExceptionErrorCodeKey", "__Internal")]
		NSString kSFKeychainItemExceptionErrorCodeKey { get; }
	}

	// @interface SFKeychainItemWrapper : NSObject
	[BaseType (typeof (NSObject))]
	interface SFKeychainItemWrapper
	{
		// @property (nonatomic) BOOL encrypted;
		[Export ("encrypted")]
		bool Encrypted { get; set; }

		// @property (readonly, nonatomic) CFTypeRef accessibleAttribute;
		[Export ("accessibleAttribute")]
		unsafe string AccessibleAttribute { get; }

		// +(BOOL)keychainAccessErrorsAreFatal;
		// +(void)setKeychainAccessErrorsAreFatal:(BOOL)errorsAreFatal;
		[Static]
		[Export ("keychainAccessErrorsAreFatal")]
		//[Verify (MethodToProperty)]
		bool KeychainAccessErrorsAreFatal { get; set; }

		// +(void)setAccessibleAttribute:(CFTypeRef)accessibleAttribute;
		[Static]
		[Export ("setAccessibleAttribute:")]
		unsafe void SetAccessibleAttribute (string accessibleAttribute);

		// +(SFKeychainItemWrapper *)itemWithIdentifier:(NSString *)identifier account:(NSString *)account;
		[Static]
		[Export ("itemWithIdentifier:account:")]
		SFKeychainItemWrapper ItemWithIdentifier (string identifier, string account);

		// -(BOOL)resetKeychainItem;
		[Export ("resetKeychainItem")]
		bool ResetKeychainItem ();

		// -(void)setPasscode:(NSString *)passcode;
		[Export ("setPasscode:")]
		void SetPasscode (string passcode);

		// -(NSString *)passcode;
		[Export ("passcode")]
		string Passcode ();

		// -(BOOL)verifyPasscode:(NSString *)passcode;
		[Export ("verifyPasscode:")]
		bool VerifyPasscode (string passcode);

		// -(OSStatus)setValueData:(NSData *)data;
		[Export ("setValueData:")]
		int SetValueData (NSData data);

		// -(NSData *)valueData;
		[Export ("valueData")]
		NSData ValueData ();

		// +(NSString *)keychainErrorCodeString:(OSStatus)errorCode;
		[Static]
		[Export ("keychainErrorCodeString:")]
		string KeychainErrorCodeString (int errorCode);
	}

	// @interface SFKeyStoreManager : NSObject
	[BaseType (typeof (NSObject))]
	interface SFKeyStoreManager
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		SFKeyStoreManager SharedInstance ();

		// -(SFEncryptionKey *)retrieveKeyWithLabel:(NSString *)keyLabel autoCreate:(BOOL)create;
		[Export ("retrieveKeyWithLabel:autoCreate:")]
		SFEncryptionKey RetrieveKeyWithLabel (string keyLabel, bool create);

		// -(SFEncryptionKey *)retrieveKeyWithLabel:(NSString *)keyLabel keyType:(SFKeyStoreKeyType)keyType autoCreate:(BOOL)create;
		[Export ("retrieveKeyWithLabel:keyType:autoCreate:")]
		SFEncryptionKey RetrieveKeyWithLabel (string keyLabel, SFKeyStoreKeyType keyType, bool create);

		// -(void)storeKey:(SFEncryptionKey *)key withLabel:(NSString *)keyLabel;
		[Export ("storeKey:withLabel:")]
		void StoreKey (SFEncryptionKey key, string keyLabel);

		// -(void)storeKey:(SFEncryptionKey *)key withKeyType:(SFKeyStoreKeyType)keyType label:(NSString *)keyLabel;
		[Export ("storeKey:withKeyType:label:")]
		void StoreKey (SFEncryptionKey key, SFKeyStoreKeyType keyType, string keyLabel);

		// -(void)removeKeyWithLabel:(NSString *)keyLabel;
		[Export ("removeKeyWithLabel:")]
		void RemoveKeyWithLabel (string keyLabel);

		// -(void)removeKeyWithLabel:(NSString *)keyLabel keyType:(SFKeyStoreKeyType)keyType;
		[Export ("removeKeyWithLabel:keyType:")]
		void RemoveKeyWithLabel (string keyLabel, SFKeyStoreKeyType keyType);

		// -(BOOL)keyWithLabelExists:(NSString *)keyLabel;
		[Export ("keyWithLabelExists:")]
		bool KeyWithLabelExists (string keyLabel);

		// -(BOOL)keyWithLabelAndKeyTypeExists:(NSString *)keyLabel keyType:(SFKeyStoreKeyType)keyType;
		[Export ("keyWithLabelAndKeyTypeExists:keyType:")]
		bool KeyWithLabelAndKeyTypeExists (string keyLabel, SFKeyStoreKeyType keyType);

		// -(SFEncryptionKey *)keyWithRandomValue;
		[Export ("keyWithRandomValue")]
		//[Verify (MethodToProperty)]
		SFEncryptionKey KeyWithRandomValue { get; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern SFLogLevel [100] SFLoggerContextLogLevels;
		[Field ("SFLoggerContextLogLevels", "__Internal")]
		long SFLoggerContextLogLevels { get; }

		// extern NSString *const _Nonnull kSFLogLevelVerboseString;
		[Field ("kSFLogLevelVerboseString", "__Internal")]
		NSString kSFLogLevelVerboseString { get; }

		// extern NSString *const _Nonnull kSFLogLevelDebugString;
		[Field ("kSFLogLevelDebugString", "__Internal")]
		NSString kSFLogLevelDebugString { get; }

		// extern NSString *const _Nonnull kSFLogLevelInfoString;
		[Field ("kSFLogLevelInfoString", "__Internal")]
		NSString kSFLogLevelInfoString { get; }

		// extern NSString *const _Nonnull kSFLogLevelWarningString;
		[Field ("kSFLogLevelWarningString", "__Internal")]
		NSString kSFLogLevelWarningString { get; }

		// extern NSString *const _Nonnull kSFLogLevelErrorString;
		[Field ("kSFLogLevelErrorString", "__Internal")]
		NSString kSFLogLevelErrorString { get; }

		// extern NSString *const _Nonnull kSFLogIdentifierDefault;
		[Field ("kSFLogIdentifierDefault", "__Internal")]
		NSString kSFLogIdentifierDefault { get; }
	}

	// @interface SFLogging (NSObject)
	[Category]
	[BaseType (typeof (NSObject))]
	interface NSObject_SFLogging
	{
		// +(NSString * _Nonnull)loggingIdentifier;
		[Static]
		[Export ("loggingIdentifier")]
		//[Verify (MethodToProperty)]
		string LoggingIdentifier { get; }

		// -(void)log:(SFLogLevel)level msg:(NSString * _Nonnull)msg;
		[Export ("log:msg:")]
		void Log (SFLogLevel level, string msg);

		// -(void)log:(SFLogLevel)level format:(NSString * _Nonnull)format, ...;
		[Internal]
		[Export ("log:format:", IsVariadic = true)]
		void Log (SFLogLevel level, string format, IntPtr varArgs);

		// -(void)log:(SFLogLevel)level identifier:(NSString * _Nonnull)logIdentifier msg:(NSString * _Nonnull)msg;
		[Export ("log:identifier:msg:")]
		void Log (SFLogLevel level, string logIdentifier, string msg);

		// -(void)log:(SFLogLevel)level identifier:(NSString * _Nonnull)logIdentifier format:(NSString * _Nonnull)format, ...;
		[Internal]
		[Export ("log:identifier:format:", IsVariadic = true)]
		void Log (SFLogLevel level, string logIdentifier, string format, IntPtr varArgs);

		// -(void)log:(SFLogLevel)level context:(SFLogContext)logContext msg:(NSString * _Nonnull)msg __attribute__((deprecated("Use log:identifier:msg: instead")));
		[Export ("log:context:msg:")]
		void Log (SFLogLevel level, SFLogContext logContext, string msg);

		// -(void)log:(SFLogLevel)level context:(SFLogContext)logContext format:(NSString * _Nonnull)format, ... __attribute__((deprecated("Use log:identifier:format: instead")));
		[Internal]
		[Export ("log:context:format:", IsVariadic = true)]
		void Log (SFLogLevel level, SFLogContext logContext, string format, IntPtr varArgs);
	}

	// @interface SFLogger : NSObject
	[BaseType (typeof (NSObject))]
	interface SFLogger
	{
		// +(instancetype _Nonnull)sharedLogger;
		[Static]
		[Export ("sharedLogger")]
		SFLogger SharedLogger ();

		// @property (getter = shouldLogToASL, assign, nonatomic) BOOL logToASL;
		[Export ("logToASL")]
		bool LogToASL { [Bind ("shouldLogToASL")] get; set; }

		// @property (getter = shouldLogToFile, assign, nonatomic) BOOL logToFile;
		[Export ("logToFile")]
		bool LogToFile { [Bind ("shouldLogToFile")] get; set; }

		// @property (assign, nonatomic) SFLogLevel logLevel;
		[Export ("logLevel", ArgumentSemantic.Assign)]
		SFLogLevel LogLevel { get; set; }

		// -(SFLogLevel)logLevelForIdentifier:(NSString * _Nullable)identifier;
		[Export ("logLevelForIdentifier:")]
		SFLogLevel LogLevelForIdentifier ([NullAllowed] string identifier);

		// -(void)setLogLevel:(SFLogLevel)logLevel forIdentifier:(NSString * _Nullable)identifier;
		[Export ("setLogLevel:forIdentifier:")]
		void SetLogLevel (SFLogLevel logLevel, [NullAllowed] string identifier);

		// -(void)setLogLevel:(SFLogLevel)logLevel forIdentifiersWithPrefix:(NSString * _Nonnull)identifierPrefix;
		[Export ("setLogLevel:forIdentifiersWithPrefix:")]
		void SetLogLevelForPrefixes (SFLogLevel logLevel, string identifierPrefix);

		// -(NSString * _Nullable)logFileContents:(NSError * _Nullable * _Nullable)error;
		[Export ("logFileContents:")]
		[return: NullAllowed]
		string LogFileContents ([NullAllowed] out NSError error);

		// +(void)log:(Class _Nonnull)cls level:(SFLogLevel)level msg:(NSString * _Nonnull)msg;
		[Static]
		[Export ("log:level:msg:")]
		void Log (Class cls, SFLogLevel level, string msg);

		// +(void)log:(Class _Nonnull)cls level:(SFLogLevel)level identifier:(NSString * _Nonnull)logIdentifier msg:(NSString * _Nonnull)msg;
		[Static]
		[Export ("log:level:identifier:msg:")]
		void Log (Class cls, SFLogLevel level, string logIdentifier, string msg);

		// +(void)logAssertionFailureInMethod:(SEL _Nonnull)method object:(id _Nullable)obj file:(NSString * _Nullable)file lineNumber:(NSUInteger)line description:(NSString * _Nonnull)desc, ...;
		[Static, Internal]
		[Export ("logAssertionFailureInMethod:object:file:lineNumber:description:", IsVariadic = true)]
		void LogAssertionFailureInMethod (Selector method, [NullAllowed] NSObject obj, [NullAllowed] string file, nuint line, string desc, IntPtr varArgs);

		// +(void)log:(Class _Nonnull)cls level:(SFLogLevel)level format:(NSString * _Nonnull)format, ...;
		[Static, Internal]
		[Export ("log:level:format:", IsVariadic = true)]
		void Log (Class cls, SFLogLevel level, string format, IntPtr varArgs);

		// +(void)log:(Class _Nonnull)cls level:(SFLogLevel)level identifier:(NSString * _Nonnull)logIdentifier format:(NSString * _Nonnull)format, ...;
		[Static, Internal]
		[Export ("log:level:identifier:format:", IsVariadic = true)]
		void Log (Class cls, SFLogLevel level, string logIdentifier, string format, IntPtr varArgs);

		// +(void)applyLogLevelFromPreferences;
		[Static]
		[Export ("applyLogLevelFromPreferences")]
		void ApplyLogLevelFromPreferences ();

		// +(void)setRecordAssertionEnabled:(BOOL)enabled;
		[Static]
		[Export ("setRecordAssertionEnabled:")]
		void SetRecordAssertionEnabled (bool enabled);

		// +(BOOL)assertionRecordedAndClear;
		[Static]
		[Export ("assertionRecordedAndClear")]
		//[Verify (MethodToProperty)]
		bool AssertionRecordedAndClear ();// { get; }

		// -(NSInteger)registerIdentifier:(NSString * _Nonnull)identifier;
		[Export ("registerIdentifier:")]
		nint RegisterIdentifier (string identifier);
	}

	// @interface MacroHelper (SFLogger)
	[Category]
	[BaseType (typeof (SFLogger))]
	interface SFLogger_MacroHelper
	{
		// +(void)logAsync:(BOOL)asynchronous level:(SFLogLevel)level flag:(SFLogFlag)flag context:(NSInteger)context file:(const char * _Nullable)file function:(const char * _Nullable)function line:(NSUInteger)line tag:(id _Nullable)tag format:(NSString * _Nullable)format, ...;
		[Static, Internal]
		[Export ("logAsync:level:flag:context:file:function:line:tag:format:", IsVariadic = true)]
		unsafe void LogAsync (bool asynchronous, SFLogLevel level, SFLogFlag flag, nint context, [NullAllowed] sbyte file, [NullAllowed] sbyte function, nuint line, [NullAllowed] NSObject tag, [NullAllowed] string format, IntPtr varArgs);
	}

	// @interface SFLoginViewController : UIViewController
	[BaseType (typeof (UIViewController))]
	interface SFLoginViewController
	{
		// +(instancetype _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		SFLoginViewController SharedInstance ();

		// @property (nonatomic, strong) UIView * _Nullable oauthView __attribute__((iboutlet));
		[NullAllowed, Export ("oauthView", ArgumentSemantic.Strong)]
		UIView OauthView { get; set; }

		// @property (nonatomic, strong) UIFont * _Nullable navBarFont;
		[NullAllowed, Export ("navBarFont", ArgumentSemantic.Strong)]
		UIFont NavBarFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable navBarTextColor;
		[NullAllowed, Export ("navBarTextColor", ArgumentSemantic.Strong)]
		UIColor NavBarTextColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable navBarColor;
		[NullAllowed, Export ("navBarColor", ArgumentSemantic.Strong)]
		UIColor NavBarColor { get; set; }

		// @property (nonatomic) BOOL showNavbar;
		[Export ("showNavbar")]
		bool ShowNavbar { get; set; }

		// @property (nonatomic) BOOL showSettingsIcon;
		[Export ("showSettingsIcon")]
		bool ShowSettingsIcon { get; set; }

		// -(void)styleNavigationBar:(UINavigationBar * _Nullable)navigationBar;
		[Export ("styleNavigationBar:")]
		void StyleNavigationBar ([NullAllowed] UINavigationBar navigationBar);
	}

	// @interface SFManagedPreferences : NSObject
	[BaseType (typeof (NSObject))]
	interface SFManagedPreferences
	{
		// +(instancetype)sharedPreferences;
		[Static]
		[Export ("sharedPreferences")]
		SFManagedPreferences SharedPreferences ();

		// @property (readonly, nonatomic) BOOL hasManagedPreferences;
		[Export ("hasManagedPreferences")]
		bool HasManagedPreferences { get; }

		// @property (readonly, nonatomic) BOOL requireCertificateAuthentication;
		[Export ("requireCertificateAuthentication")]
		bool RequireCertificateAuthentication { get; }

		// @property (readonly, nonatomic) NSArray * loginHosts;
		[Export ("loginHosts")]
		//[Verify (StronglyTypedNSArray)]
		string [] LoginHosts { get; }

		// @property (readonly, nonatomic) NSArray * loginHostLabels;
		[Export ("loginHostLabels")]
		//[Verify (StronglyTypedNSArray)]
		string [] LoginHostLabels { get; }

		// @property (readonly, nonatomic) NSString * connectedAppId;
		[Export ("connectedAppId")]
		string ConnectedAppId { get; }

		// @property (readonly, nonatomic) NSString * connectedAppCallbackUri;
		[Export ("connectedAppCallbackUri")]
		string ConnectedAppCallbackUri { get; }

		// @property (readonly, nonatomic) BOOL clearClipboardOnBackground;
		[Export ("clearClipboardOnBackground")]
		bool ClearClipboardOnBackground { get; }

		// @property (readonly, nonatomic) BOOL onlyShowAuthorizedHosts;
		[Export ("onlyShowAuthorizedHosts")]
		bool OnlyShowAuthorizedHosts { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * rawPreferences;
		[Export ("rawPreferences", ArgumentSemantic.Strong)]
		NSDictionary RawPreferences { get; }
	}

	// @interface SFOAuthCrypto : NSObject
	[BaseType (typeof (NSObject))]
	interface SFOAuthCrypto
	{
		// -(id)initWithOperation:(SFOAuthCryptoOperation)operation key:(NSData *)key;
		[Export ("initWithOperation:key:")]
		IntPtr Constructor (SFOAuthCryptoOperation operation, NSData key);

		// -(void)encryptData:(NSData *)data;
		[Export ("encryptData:")]
		void EncryptData (NSData data);

		// -(NSData *)decryptData:(NSData *)data;
		[Export ("decryptData:")]
		NSData DecryptData (NSData data);

		// -(NSData *)finalizeCipher;
		[Export ("finalizeCipher")]
		//[Verify (MethodToProperty)]
		NSData FinalizeCipher ();// { get; }
	}

	// @interface SFOAuthKeychainCredentials : SFOAuthCredentials
	[BaseType (typeof (SFOAuthCredentials))]
	interface SFOAuthKeychainCredentials
	{
		// -(NSData *)keyMacForService:(NSString *)service;
		[Export ("keyMacForService:")]
		NSData KeyMacForService (string service);

		// -(NSData *)keyVendorIdForService:(NSString *)service;
		[Export ("keyVendorIdForService:")]
		NSData KeyVendorIdForService (string service);

		// -(NSData *)keyBaseAppIdForService:(NSString *)service;
		[Export ("keyBaseAppIdForService:")]
		NSData KeyBaseAppIdForService (string service);

		// -(SFEncryptionKey *)keyStoreKeyForService:(NSString *)service;
		[Export ("keyStoreKeyForService:")]
		SFEncryptionKey KeyStoreKeyForService (string service);

		// -(NSData *)keyWithSeed:(NSString *)seed service:(NSString *)service;
		[Export ("keyWithSeed:service:")]
		NSData KeyWithSeed (string seed, string service);

		// -(NSString *)refreshTokenWithKey:(NSData *)key;
		[Export ("refreshTokenWithKey:")]
		string RefreshTokenWithKey (NSData key);

		// -(NSString *)refreshTokenWithSFEncryptionKey:(SFEncryptionKey *)encryptionKey;
		[Export ("refreshTokenWithSFEncryptionKey:")]
		string RefreshTokenWithSFEncryptionKey (SFEncryptionKey encryptionKey);

		// -(void)setRefreshToken:(NSString *)token withSFEncryptionKey:(SFEncryptionKey *)key;
		[Export ("setRefreshToken:withSFEncryptionKey:")]
		void SetRefreshToken (string token, SFEncryptionKey key);

		// -(NSString *)accessTokenWithKey:(NSData *)key;
		[Export ("accessTokenWithKey:")]
		string AccessTokenWithKey (NSData key);

		// -(NSString *)accessTokenWithSFEncryptionKey:(SFEncryptionKey *)encryptionKey;
		[Export ("accessTokenWithSFEncryptionKey:")]
		string AccessTokenWithSFEncryptionKey (SFEncryptionKey encryptionKey);

		// -(void)setAccessToken:(NSString *)token withSFEncryptionKey:(SFEncryptionKey *)key;
		[Export ("setAccessToken:withSFEncryptionKey:")]
		void SetAccessToken (string token, SFEncryptionKey key);

		// -(void)updateTokenEncryption;
		[Export ("updateTokenEncryption")]
		void UpdateTokenEncryption ();

		// -(void)setAccessToken:(NSString *)token withKey:(NSData *)key;
		[Export ("setAccessToken:withKey:")]
		void SetAccessToken (string token, NSData key);

		// -(void)setRefreshToken:(NSString *)token withKey:(NSData *)key;
		[Export ("setRefreshToken:withKey:")]
		void SetRefreshToken (string token, NSData key);
	}

	// @interface SFOAuthOrgAuthConfiguration : NSObject
	[BaseType (typeof (NSObject))]
	interface SFOAuthOrgAuthConfiguration
	{
		// @property (readonly, nonatomic) BOOL useNativeBrowserForAuth;
		[Export ("useNativeBrowserForAuth")]
		bool UseNativeBrowserForAuth { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * authConfigDict;
		[Export ("authConfigDict", ArgumentSemantic.Strong)]
		NSDictionary AuthConfigDict { get; }

		// -(id)initWithConfigDict:(NSDictionary *)authConfigDict;
		[Export ("initWithConfigDict:")]
		IntPtr Constructor (NSDictionary authConfigDict);
	}

	// @interface SFOAuthSessionRefresher : NSObject
	[BaseType (typeof (NSObject))]
	interface SFOAuthSessionRefresher
	{
		// -(instancetype)initWithCredentials:(SFOAuthCredentials *)credentials __attribute__((objc_designated_initializer));
		[Export ("initWithCredentials:")]
		[DesignatedInitializer]
		IntPtr Constructor (SFOAuthCredentials credentials);

		// -(void)refreshSessionWithCompletion:(void (^)(SFOAuthCredentials *))completionBlock error:(void (^)(NSError *))errorBlock;
		[Export ("refreshSessionWithCompletion:error:")]
		void RefreshSessionWithCompletion (Action<SFOAuthCredentials> completionBlock, Action<NSError> errorBlock);
	}

	// @interface SFPasscodeKeyStore : SFKeyStore
	[BaseType (typeof (SFKeyStore))]
	interface SFPasscodeKeyStore
	{
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const SFPasscodeResetNotification;
		[Field ("SFPasscodeResetNotification", "__Internal")]
		NSString SFPasscodeResetNotification { get; }

		// extern NSString *const SFPasscodeResetOldPasscodeKey;
		[Field ("SFPasscodeResetOldPasscodeKey", "__Internal")]
		NSString SFPasscodeResetOldPasscodeKey { get; }

		// extern NSString *const SFPasscodeResetNewPasscodeKey;
		[Field ("SFPasscodeResetNewPasscodeKey", "__Internal")]
		NSString SFPasscodeResetNewPasscodeKey { get; }
	}

	// @protocol SFPasscodeManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface SFPasscodeManagerDelegate
	{
		// @optional -(void)passcodeManager:(SFPasscodeManager *)manager didChangeEncryptionKey:(NSString *)oldKey toEncryptionKey:(NSString *)newKey;
		[Export ("passcodeManager:didChangeEncryptionKey:toEncryptionKey:")]
		void DidChangeEncryptionKey (SFPasscodeManager manager, string oldKey, string newKey);
	}

	// @interface SFPasscodeManager : NSObject
	[BaseType (typeof (NSObject))]
	interface SFPasscodeManager
	{
		// +(SFPasscodeManager *)sharedManager;
		[Static]
		[Export ("sharedManager")]
		//[Verify (MethodToProperty)]
		SFPasscodeManager SharedManager { get; }

		// @property (readonly, nonatomic) NSString * encryptionKey;
		[Export ("encryptionKey")]
		string EncryptionKey { get; }

		// @property (copy, nonatomic) NSString * preferredPasscodeProvider;
		[Export ("preferredPasscodeProvider")]
		string PreferredPasscodeProvider { get; set; }

		// -(void)addDelegate:(id<SFPasscodeManagerDelegate>)delegate;
		[Export ("addDelegate:")]
		void AddDelegate (SFPasscodeManagerDelegate @delegate);

		// -(void)removeDelegate:(id<SFPasscodeManagerDelegate>)delegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (SFPasscodeManagerDelegate @delegate);

		// -(BOOL)passcodeIsSet;
		[Export ("passcodeIsSet")]
		//[Verify (MethodToProperty)]
		bool PasscodeIsSet { get; }

		// -(void)resetPasscode;
		[Export ("resetPasscode")]
		void ResetPasscode ();

		// -(BOOL)verifyPasscode:(NSString *)passcode;
		[Export ("verifyPasscode:")]
		bool VerifyPasscode (string passcode);

		// -(void)changePasscode:(NSString *)newPasscode;
		[Export ("changePasscode:")]
		void ChangePasscode (string newPasscode);

		// -(void)setPasscode:(NSString *)newPasscode;
		[Export ("setPasscode:")]
		void SetPasscode (string newPasscode);
	}

	// @interface  (SFPasscodeManager)
	[Category]
	[BaseType (typeof (SFPasscodeManager))]
	interface SFPasscodeManager_
	{
		// @property (nonatomic, strong) NSHashTable<id<SFPasscodeManagerDelegate>> * _Nonnull delegates;
		//[Export ("delegates", ArgumentSemantic.Strong)]
		//NSHashTable<SFPasscodeManagerDelegate> Delegates { get; set; }

		// -(void)enumerateDelegates:(void (^ _Nullable)(id<SFPasscodeManagerDelegate> _Nonnull))block;
		[Export ("enumerateDelegates:")]
		void EnumerateDelegates ([NullAllowed] Action<SFPasscodeManagerDelegate> block);

		// -(void)setEncryptionKey:(NSString * _Nullable)newEncryptionKey;
		[Export ("setEncryptionKey:")]
		void SetEncryptionKey ([NullAllowed] string newEncryptionKey);

		// -(void)setEncryptionKeyForPasscode:(NSString * _Nonnull)passcode;
		[Export ("setEncryptionKeyForPasscode:")]
		void SetEncryptionKeyForPasscode (string passcode);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const SFPasscodeProviderId _Nonnull kSFPasscodeProviderSHA256;
		[Field ("kSFPasscodeProviderSHA256", "__Internal")]
		NSString kSFPasscodeProviderSHA256 { get; }

		// extern const SFPasscodeProviderId _Nonnull kSFPasscodeProviderPBKDF2;
		[Field ("kSFPasscodeProviderPBKDF2", "__Internal")]
		NSString kSFPasscodeProviderPBKDF2 { get; }
	}

	// @protocol SFPasscodeProvider <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface ISFPasscodeProvider
	{
		// @required @property (readonly, nonatomic) SFPasscodeProviderId _Nonnull providerName;
		[Abstract]
		[Export ("providerName")]
		string ProviderName { get; }

		// @required -(instancetype _Nonnull)initWithProviderName:(SFPasscodeProviderId _Nonnull)providerName;
		[Abstract]
		// [Static]
		[Export ("initWithProviderName:")]
		IntPtr Create (string providerName);

		// @required -(void)resetPasscodeData;
		[Abstract]
		[Export ("resetPasscodeData")]
		void ResetPasscodeData ();

		// @required -(BOOL)verifyPasscode:(NSString * _Nonnull)passcode;
		[Abstract]
		[Export ("verifyPasscode:")]
		bool VerifyPasscode (string passcode);

		// @required -(NSString * _Nullable)hashedVerificationPasscode;
		[Abstract]
		[NullAllowed, Export ("hashedVerificationPasscode")]
		//[Verify (MethodToProperty)]
		string HashedVerificationPasscode { get; }

		// @required -(void)setVerificationPasscode:(NSString * _Nonnull)newPasscode;
		[Abstract]
		[Export ("setVerificationPasscode:")]
		void SetVerificationPasscode (string newPasscode);

		// @required -(NSString * _Nonnull)generateEncryptionKey:(NSString * _Nonnull)passcode;
		[Abstract]
		[Export ("generateEncryptionKey:")]
		string GenerateEncryptionKey (string passcode);
	}

	// @interface SFPasscodeProviderManager : NSObject
	[BaseType (typeof (NSObject))]
	interface SFPasscodeProviderManager
	{
		// +(SFPasscodeProviderId _Nonnull)currentPasscodeProviderName;
		[Static]
		[Export ("currentPasscodeProviderName")]
		//[Verify (MethodToProperty)]
		string CurrentPasscodeProviderName { get; }

		// +(void)setCurrentPasscodeProviderByName:(SFPasscodeProviderId _Nonnull)providerName;
		[Static]
		[Export ("setCurrentPasscodeProviderByName:")]
		void SetCurrentPasscodeProviderByName (string providerName);

		// +(id<SFPasscodeProvider> _Nonnull)currentPasscodeProvider;
		[Static]
		[Export ("currentPasscodeProvider")]
		//[Verify (MethodToProperty)]
		ISFPasscodeProvider CurrentPasscodeProvider { get; }

		// +(id<SFPasscodeProvider> _Nullable)passcodeProviderForProviderName:(SFPasscodeProviderId _Nonnull)providerName;
		[Static]
		[Export ("passcodeProviderForProviderName:")]
		[return: NullAllowed]
		ISFPasscodeProvider PasscodeProviderForProviderName (string providerName);

		// +(void)addPasscodeProvider:(id<SFPasscodeProvider> _Nonnull)provider;
		[Static]
		[Export ("addPasscodeProvider:")]
		void AddPasscodeProvider (ISFPasscodeProvider provider);

		// +(void)removePasscodeProviderWithName:(SFPasscodeProviderId _Nonnull)providerName;
		[Static]
		[Export ("removePasscodeProviderWithName:")]
		void RemovePasscodeProviderWithName (string providerName);
	}

	// @interface SFPasscodeViewController : SFAbstractPasscodeViewController <UITextFieldDelegate>
	[BaseType (typeof (SFAbstractPasscodeViewController))]
	interface SFPasscodeViewController : IUITextFieldDelegate
	{
		// -(id)initForPasscodeCreation:(SFPasscodeConfigurationData)configData;
		[Static]
		[Export ("initForPasscodeCreation:")]
		IntPtr CreateForPasscodeCreation (SFPasscodeConfigurationData configData);

		// -(id)initForPasscodeChange:(SFPasscodeConfigurationData)configData;
		[Static]
		[Export ("initForPasscodeChange:")]
		IntPtr CreateForPasscodeChange (SFPasscodeConfigurationData configData);
	}

	// @interface SFPathUtil : NSObject
	[BaseType (typeof (NSObject))]
	interface SFPathUtil
	{
		// +(void)createFileItemIfNotExist:(NSString *)path skipBackup:(BOOL)skipBackup;
		[Static]
		[Export ("createFileItemIfNotExist:skipBackup:")]
		void CreateFileItemIfNotExist (string path, bool skipBackup);

		// +(NSString *)applicationDocumentDirectory;
		[Static]
		[Export ("applicationDocumentDirectory")]
		//[Verify (MethodToProperty)]
		string ApplicationDocumentDirectory { get; }

		// +(NSString *)applicationCacheDirectory;
		[Static]
		[Export ("applicationCacheDirectory")]
		//[Verify (MethodToProperty)]
		string ApplicationCacheDirectory { get; }

		// +(NSString *)applicationLibraryDirectory;
		[Static]
		[Export ("applicationLibraryDirectory")]
		//[Verify (MethodToProperty)]
		string ApplicationLibraryDirectory { get; }

		// +(NSString *)absolutePathForDocumentFolder:(NSString *)folder;
		[Static]
		[Export ("absolutePathForDocumentFolder:")]
		string AbsolutePathForDocumentFolder (string folder);

		// +(NSString *)absolutePathForCacheFolder:(NSString *)folder;
		[Static]
		[Export ("absolutePathForCacheFolder:")]
		string AbsolutePathForCacheFolder (string folder);

		// +(NSString *)absolutePathForLibraryFolder:(NSString *)folder;
		[Static]
		[Export ("absolutePathForLibraryFolder:")]
		string AbsolutePathForLibraryFolder (string folder);

		// +(void)secureFilePath:(NSString *)filePath markAsNotBackup:(BOOL)notbackupFlag;
		[Static]
		[Export ("secureFilePath:markAsNotBackup:")]
		void SecureFilePath (string filePath, bool notbackupFlag);

		// +(NSString *)absolutePathForDocumentFolder:(NSString *)folder fileProtection:(NSString *)fileProtection;
		[Static]
		[Export ("absolutePathForDocumentFolder:fileProtection:")]
		string AbsolutePathForDocumentFolder (string folder, string fileProtection);

		// +(NSString *)absolutePathForCacheFolder:(NSString *)folder fileProtection:(NSString *)fileProtection;
		[Static]
		[Export ("absolutePathForCacheFolder:fileProtection:")]
		string AbsolutePathForCacheFolder (string folder, string fileProtection);

		// +(NSString *)absolutePathForLibraryFolder:(NSString *)folder fileProtection:(NSString *)fileProtection;
		[Static]
		[Export ("absolutePathForLibraryFolder:fileProtection:")]
		string AbsolutePathForLibraryFolder (string folder, string fileProtection);

		// +(void)secureFilePath:(NSString *)filePath markAsNotBackup:(BOOL)notbackupFlag fileProtection:(NSString *)fileProtection;
		[Static]
		[Export ("secureFilePath:markAsNotBackup:fileProtection:")]
		void SecureFilePath (string filePath, bool notbackupFlag, string fileProtection);

		// +(void)secureFileAtPath:(NSString *)filePath recursive:(BOOL)recursive fileProtection:(NSString *)fileProtection;
		[Static]
		[Export ("secureFileAtPath:recursive:fileProtection:")]
		void SecureFileAtPath (string filePath, bool recursive, string fileProtection);
	}

	// @interface SFPBKDF2PasscodeProvider : NSObject <SFPasscodeProvider>
	[BaseType (typeof (NSObject))]
	interface SFPBKDF2PasscodeProvider : ISFPasscodeProvider
	{
		// @property (assign, nonatomic) NSUInteger saltLengthInBytes;
		[Export ("saltLengthInBytes")]
		nuint SaltLengthInBytes { get; set; }

		// @property (assign, nonatomic) NSUInteger numDerivationRounds;
		[Export ("numDerivationRounds")]
		nuint NumDerivationRounds { get; set; }

		// @property (assign, nonatomic) NSUInteger derivedKeyLengthInBytes;
		[Export ("derivedKeyLengthInBytes")]
		nuint DerivedKeyLengthInBytes { get; set; }
	}

	// @interface SFPBKDFData : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	interface SFPBKDFData : INSCoding
	{
		// @property (nonatomic, strong) NSData * derivedKey;
		[Export ("derivedKey", ArgumentSemantic.Strong)]
		NSData DerivedKey { get; set; }

		// @property (nonatomic, strong) NSData * salt;
		[Export ("salt", ArgumentSemantic.Strong)]
		NSData Salt { get; set; }

		// @property (assign, nonatomic) NSUInteger numDerivationRounds;
		[Export ("numDerivationRounds")]
		nuint NumDerivationRounds { get; set; }

		// @property (assign, nonatomic) NSUInteger derivedKeyLength;
		[Export ("derivedKeyLength")]
		nuint DerivedKeyLength { get; set; }

		// -(id)initWithKey:(NSData *)key salt:(NSData *)salt derivationRounds:(NSUInteger)derivationRounds derivedKeyLength:(NSUInteger)derivedKeyLength;
		[Export ("initWithKey:salt:derivationRounds:derivedKeyLength:")]
		IntPtr Constructor (NSData key, NSData salt, nuint derivationRounds, nuint derivedKeyLength);
	}

	// @interface SFPreferences : NSObject
	[BaseType (typeof (NSObject))]
	interface SFPreferences
	{
		// @property (readonly, nonatomic, strong) NSString * path;
		[Export ("path", ArgumentSemantic.Strong)]
		string Path { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * dictionaryRepresentation;
		[Export ("dictionaryRepresentation", ArgumentSemantic.Copy)]
		NSDictionary DictionaryRepresentation { get; }

		// +(instancetype)globalPreferences;
		[Static]
		[Export ("globalPreferences")]
		SFPreferences GlobalPreferences ();

		// +(instancetype)sharedPreferencesForScope:(SFUserAccountScope)scope user:(SFUserAccount *)user;
		[Static]
		[Export ("sharedPreferencesForScope:user:")]
		SFPreferences SharedPreferencesForScope (SFUserAccountScope scope, SFUserAccount user);

		// +(instancetype)currentOrgLevelPreferences;
		[Static]
		[Export ("currentOrgLevelPreferences")]
		SFPreferences CurrentOrgLevelPreferences ();

		// +(instancetype)currentUserLevelPreferences;
		[Static]
		[Export ("currentUserLevelPreferences")]
		SFPreferences CurrentUserLevelPreferences ();

		// +(instancetype)currentCommunityLevelPreferences;
		[Static]
		[Export ("currentCommunityLevelPreferences")]
		SFPreferences CurrentCommunityLevelPreferences ();

		// -(id)objectForKey:(NSString *)key;
		[Export ("objectForKey:")]
		NSObject ObjectForKey (string key);

		// -(void)setObject:(id)object forKey:(NSString *)key;
		[Export ("setObject:forKey:")]
		void SetObject (NSObject @object, string key);

		// -(void)removeObjectForKey:(NSString *)key;
		[Export ("removeObjectForKey:")]
		void RemoveObjectForKey (string key);

		// -(BOOL)boolForKey:(NSString *)key;
		[Export ("boolForKey:")]
		bool BoolForKey (string key);

		// -(void)setBool:(BOOL)value forKey:(NSString *)key;
		[Export ("setBool:forKey:")]
		void SetBool (bool value, string key);

		// -(NSInteger)integerForKey:(NSString *)key;
		[Export ("integerForKey:")]
		nint IntegerForKey (string key);

		// -(void)setInteger:(NSInteger)value forKey:(NSString *)key;
		[Export ("setInteger:forKey:")]
		void SetInteger (nint value, string key);

		// -(NSString *)stringForKey:(NSString *)key;
		[Export ("stringForKey:")]
		string StringForKey (string key);

		// -(void)synchronize;
		[Export ("synchronize")]
		void Synchronize ();

		// -(void)removeAllObjects;
		[Export ("removeAllObjects")]
		void RemoveAllObjects ();
	}

	// @interface SFPushNotificationManager : NSObject
	[BaseType (typeof (NSObject))]
	interface SFPushNotificationManager
	{
		// @property (nonatomic, strong) NSString * deviceToken;
		[Export ("deviceToken", ArgumentSemantic.Strong)]
		string DeviceToken { get; set; }

		// @property (nonatomic, strong) NSString * deviceSalesforceId;
		[Export ("deviceSalesforceId", ArgumentSemantic.Strong)]
		string DeviceSalesforceId { get; set; }

		// +(SFPushNotificationManager *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		//[Verify (MethodToProperty)]
		SFPushNotificationManager SharedInstance { get; }

		// -(void)registerForRemoteNotifications;
		[Export ("registerForRemoteNotifications")]
		void RegisterForRemoteNotifications ();

		// -(void)didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)deviceTokenData;
		[Export ("didRegisterForRemoteNotificationsWithDeviceToken:")]
		void DidRegisterForRemoteNotificationsWithDeviceToken (NSData deviceTokenData);

		// -(BOOL)registerForSalesforceNotifications;
		[Export ("registerForSalesforceNotifications")]
		//[Verify (MethodToProperty)]
		//bool RegisterForSalesforceNotifications { get; }
		bool RegisterForSalesforceNotifications ();

		// -(BOOL)unregisterSalesforceNotifications;
		[Export ("unregisterSalesforceNotifications")]
		//[Verify (MethodToProperty)]
		//bool UnregisterSalesforceNotifications { get; }
		bool UnregisterSalesforceNotifications ();

		// -(BOOL)unregisterSalesforceNotifications:(SFUserAccount *)user;
		[Export ("unregisterSalesforceNotifications:")]
		bool UnregisterSalesforceNotifications (SFUserAccount user);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kSFDefaultRestEndpoint;
		[Field ("kSFDefaultRestEndpoint", "__Internal")]
		NSString kSFDefaultRestEndpoint { get; }
	}

	// @protocol SFRestDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface ISFRestDelegate
	{
		// @optional -(void)request:(SFRestRequest * _Nonnull)request didLoadResponse:(id _Nonnull)dataResponse;
		[Export ("request:didLoadResponse:")]
		void Request (SFRestRequest request, NSObject dataResponse);

		// @optional -(void)request:(SFRestRequest * _Nonnull)request didFailLoadWithError:(NSError * _Nonnull)error;
		[Export ("request:didFailLoadWithError:")]
		void Request (SFRestRequest request, NSError error);

		// @optional -(void)requestDidCancelLoad:(SFRestRequest * _Nonnull)request;
		[Export ("requestDidCancelLoad:")]
		void RequestDidCancelLoad (SFRestRequest request);

		// @optional -(void)requestDidTimeout:(SFRestRequest * _Nonnull)request;
		[Export ("requestDidTimeout:")]
		void RequestDidTimeout (SFRestRequest request);
	}

	// @interface SFRestRequest : NSObject
	[BaseType (typeof (NSObject))]
	interface SFRestRequest
	{
		// @property (assign, nonatomic) SFRestMethod method;
		[Export ("method", ArgumentSemantic.Assign)]
		SFRestMethod Method { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull path;
		[Export ("path", ArgumentSemantic.Strong)]
		string Path { get; set; }

		// @property (nonatomic, strong) NSDictionary<NSString *,NSObject *> * _Nullable queryParams;
		[NullAllowed, Export ("queryParams", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> QueryParams { get; set; }

		// @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nonnull customHeaders;
		[Export ("customHeaders", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSString> CustomHeaders { get; set; }

		// @property (nonatomic, strong) SFRestAPISalesforceAction * _Nonnull action;
		[Export ("action", ArgumentSemantic.Strong)]
		SFRestAPISalesforceAction Action { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ISFRestDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SFRestDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull endpoint;
		[Export ("endpoint", ArgumentSemantic.Strong)]
		string Endpoint { get; set; }

		// @property (assign, nonatomic) BOOL requiresAuthentication;
		[Export ("requiresAuthentication")]
		bool RequiresAuthentication { get; set; }

		// @property (assign, nonatomic) BOOL parseResponse;
		[Export ("parseResponse")]
		bool ParseResponse { get; set; }

		// -(void)prepareRequestForSend;
		[Export ("prepareRequestForSend")]
		void PrepareRequestForSend ();

		// -(void)setHeaderValue:(NSString * _Nullable)value forHeaderName:(NSString * _Nonnull)name;
		[Export ("setHeaderValue:forHeaderName:")]
		void SetHeaderValue ([NullAllowed] string value, string name);

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// -(void)addPostFileData:(NSData * _Nonnull)fileData paramName:(NSString * _Nonnull)paramName fileName:(NSString * _Nonnull)fileName mimeType:(NSString * _Nonnull)mimeType;
		[Export ("addPostFileData:paramName:fileName:mimeType:")]
		void AddPostFileData (NSData fileData, string paramName, string fileName, string mimeType);

		// -(void)setCustomRequestBodyString:(NSString * _Nonnull)bodyString contentType:(NSString * _Nonnull)contentType;
		[Export ("setCustomRequestBodyString:contentType:")]
		void SetCustomRequestBodyString (string bodyString, string contentType);

		// -(void)setCustomRequestBodyData:(NSData * _Nonnull)bodyData contentType:(NSString * _Nonnull)contentType;
		[Export ("setCustomRequestBodyData:contentType:")]
		void SetCustomRequestBodyData (NSData bodyData, string contentType);

		// -(void)setCustomRequestBodyStream:(NSInputStream * _Nonnull (^ _Nonnull)(void))bodyStreamBlock contentType:(NSString * _Nonnull)contentType;
		[Export ("setCustomRequestBodyStream:contentType:")]
		void SetCustomRequestBodyStream (Func<NSInputStream> bodyStreamBlock, string contentType);

		// +(BOOL)isNetworkError:(NSError * _Nonnull)error;
		[Static]
		[Export ("isNetworkError:")]
		bool IsNetworkError (NSError error);

		// +(SFRestMethod)sfRestMethodFromHTTPMethod:(NSString * _Nonnull)httpMethod;
		[Static]
		[Export ("sfRestMethodFromHTTPMethod:")]
		SFRestMethod SfRestMethodFromHTTPMethod (string httpMethod);

		// +(instancetype _Nonnull)requestWithMethod:(SFRestMethod)method path:(NSString * _Nonnull)path queryParams:(NSDictionary<NSString *,NSString *> * _Nullable)queryParams;
		[Static]
		[Export ("requestWithMethod:path:queryParams:")]
		SFRestRequest RequestWithMethod (SFRestMethod method, string path, [NullAllowed] NSDictionary<NSString, NSString> queryParams);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kSFRestErrorDomain;
		[Field ("kSFRestErrorDomain", "__Internal")]
		NSString kSFRestErrorDomain { get; }

		// extern const NSInteger kSFRestErrorCode;
		[Field ("kSFRestErrorCode", "__Internal")]
		nint kSFRestErrorCode { get; }

		// extern NSString *const _Nonnull kSFRestDefaultAPIVersion;
		[Field ("kSFRestDefaultAPIVersion", "__Internal")]
		NSString kSFRestDefaultAPIVersion { get; }
	}

	// @interface SFRestAPI : NSObject
	[BaseType (typeof (NSObject))]
	interface SFRestAPI
	{
		// @property (nonatomic, strong) SFOAuthCoordinator * _Nonnull coordinator;
		[Export ("coordinator", ArgumentSemantic.Strong)]
		SFOAuthCoordinator Coordinator { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull apiVersion;
		[Export ("apiVersion", ArgumentSemantic.Strong)]
		string ApiVersion { get; set; }

		// +(SFRestAPI * _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		//[Verify (MethodToProperty)]
		SFRestAPI SharedInstance { get; }

		// +(void)setIsTestRun:(BOOL)isTestRun;
		[Static]
		[Export ("setIsTestRun:")]
		void SetIsTestRun (bool isTestRun);

		// +(BOOL)getIsTestRun;
		[Static]
		[Export ("getIsTestRun")]
		//[Verify (MethodToProperty)]
		bool IsTestRun { get; }

		// -(void)cleanup;
		[Export ("cleanup")]
		void Cleanup ();

		// -(void)cancelAllRequests;
		[Export ("cancelAllRequests")]
		void CancelAllRequests ();

		// -(SFRestAPISalesforceAction * _Nonnull)send:(SFRestRequest * _Nonnull)request delegate:(id<SFRestDelegate> _Nullable)delegate;
		[Export ("send:delegate:")]
		SFRestAPISalesforceAction Send (SFRestRequest request, [NullAllowed] ISFRestDelegate @delegate);

		// -(SFRestRequest * _Nonnull)requestForVersions;
		[Export ("requestForVersions")]
		//[Verify (MethodToProperty)]
		SFRestRequest RequestForVersions { get; }

		// -(SFRestRequest * _Nonnull)requestForResources;
		[Export ("requestForResources")]
		//[Verify (MethodToProperty)]
		SFRestRequest RequestForResources { get; }

		// -(SFRestRequest * _Nonnull)requestForDescribeGlobal;
		[Export ("requestForDescribeGlobal")]
		//[Verify (MethodToProperty)]
		SFRestRequest RequestForDescribeGlobal { get; }

		// -(SFRestRequest * _Nonnull)requestForMetadataWithObjectType:(NSString * _Nonnull)objectType;
		[Export ("requestForMetadataWithObjectType:")]
		SFRestRequest RequestForMetadataWithObjectType (string objectType);

		// -(SFRestRequest * _Nonnull)requestForDescribeWithObjectType:(NSString * _Nonnull)objectType;
		[Export ("requestForDescribeWithObjectType:")]
		SFRestRequest RequestForDescribeWithObjectType (string objectType);

		// -(SFRestRequest * _Nonnull)requestForRetrieveWithObjectType:(NSString * _Nonnull)objectType objectId:(NSString * _Nonnull)objectId fieldList:(NSString * _Nullable)fieldList;
		[Export ("requestForRetrieveWithObjectType:objectId:fieldList:")]
		SFRestRequest RequestForRetrieveWithObjectType (string objectType, string objectId, [NullAllowed] string fieldList);

		// -(SFRestRequest * _Nonnull)requestForCreateWithObjectType:(NSString * _Nonnull)objectType fields:(NSDictionary<NSString *,id> * _Nullable)fields;
		[Export ("requestForCreateWithObjectType:fields:")]
		SFRestRequest RequestForCreateWithObjectType (string objectType, [NullAllowed] NSDictionary<NSString, NSObject> fields);

		// -(SFRestRequest * _Nonnull)requestForUpsertWithObjectType:(NSString * _Nonnull)objectType externalIdField:(NSString * _Nonnull)externalIdField externalId:(NSString * _Nonnull)externalId fields:(NSDictionary<NSString *,id> * _Nonnull)fields;
		[Export ("requestForUpsertWithObjectType:externalIdField:externalId:fields:")]
		SFRestRequest RequestForUpsertWithObjectType (string objectType, string externalIdField, string externalId, NSDictionary<NSString, NSObject> fields);

		// -(SFRestRequest * _Nonnull)requestForUpdateWithObjectType:(NSString * _Nonnull)objectType objectId:(NSString * _Nonnull)objectId fields:(NSDictionary<NSString *,id> * _Nullable)fields;
		[Export ("requestForUpdateWithObjectType:objectId:fields:")]
		SFRestRequest RequestForUpdateWithObjectType (string objectType, string objectId, [NullAllowed] NSDictionary<NSString, NSObject> fields);

		// -(SFRestRequest * _Nonnull)requestForDeleteWithObjectType:(NSString * _Nonnull)objectType objectId:(NSString * _Nonnull)objectId;
		[Export ("requestForDeleteWithObjectType:objectId:")]
		SFRestRequest RequestForDeleteWithObjectType (string objectType, string objectId);

		// -(SFRestRequest * _Nonnull)requestForQuery:(NSString * _Nonnull)soql;
		[Export ("requestForQuery:")]
		SFRestRequest RequestForQuery (string soql);

		// -(SFRestRequest * _Nonnull)requestForQueryAll:(NSString * _Nonnull)soql;
		[Export ("requestForQueryAll:")]
		SFRestRequest RequestForQueryAll (string soql);

		// -(SFRestRequest * _Nonnull)requestForSearch:(NSString * _Nonnull)sosl;
		[Export ("requestForSearch:")]
		SFRestRequest RequestForSearch (string sosl);

		// -(SFRestRequest * _Nonnull)requestForSearchScopeAndOrder;
		[Export ("requestForSearchScopeAndOrder")]
		//[Verify (MethodToProperty)]
		//SFRestRequest RequestForSearchScopeAndOrder { get; }
		SFRestRequest RequestForSearchScopeAndOrder ();

		// -(SFRestRequest * _Nonnull)requestForSearchResultLayout:(NSString * _Nonnull)objectList;
		[Export ("requestForSearchResultLayout:")]
		SFRestRequest RequestForSearchResultLayout (string objectList);

		// +(NSString * _Nonnull)userAgentString;
		[Static]
		[Export ("userAgentString")]
		//[Verify (MethodToProperty)]
		//string UserAgentString { get; }
		string UserAgentString ();

		// +(NSString * _Nonnull)userAgentString:(NSString * _Nonnull)qualifier;
		[Static]
		[Export ("userAgentString:")]
		string UserAgentString (string qualifier);
	}

	// @interface Blocks (SFRestAPI) <SFRestDelegate>
	[Category]
	[BaseType (typeof (SFRestAPI))]
	interface SFRestAPI_Blocks// : ISFRestDelegate
	{
		// +(NSError * _Nonnull)errorWithDescription:(NSString * _Nonnull)description;
		[Static]
		[Export ("errorWithDescription:")]
		NSError ErrorWithDescription (string description);

		// -(void)sendRESTRequest:(SFRestRequest * _Nonnull)request failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestResponseBlock _Nonnull)completeBlock;
		[Export ("sendRESTRequest:failBlock:completeBlock:")]
		void SendRESTRequest (SFRestRequest request, SFRestFailBlock failBlock, SFRestResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performSOQLQuery:(NSString * _Nonnull)query failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performSOQLQuery:failBlock:completeBlock:")]
		SFRestRequest PerformSOQLQuery (string query, SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performSOQLQueryAll:(NSString * _Nonnull)query failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performSOQLQueryAll:failBlock:completeBlock:")]
		SFRestRequest PerformSOQLQueryAll (string query, SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performSOSLSearch:(NSString * _Nonnull)search failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestArrayResponseBlock _Nonnull)completeBlock;
		[Export ("performSOSLSearch:failBlock:completeBlock:")]
		SFRestRequest PerformSOSLSearch (string search, SFRestFailBlock failBlock, SFRestArrayResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performDescribeGlobalWithFailBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performDescribeGlobalWithFailBlock:completeBlock:")]
		SFRestRequest PerformDescribeGlobalWithFailBlock (SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performDescribeWithObjectType:(NSString * _Nonnull)objectType failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performDescribeWithObjectType:failBlock:completeBlock:")]
		SFRestRequest PerformDescribeWithObjectType (string objectType, SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performMetadataWithObjectType:(NSString * _Nonnull)objectType failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performMetadataWithObjectType:failBlock:completeBlock:")]
		SFRestRequest PerformMetadataWithObjectType (string objectType, SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performRetrieveWithObjectType:(NSString * _Nonnull)objectType objectId:(NSString * _Nonnull)objectId fieldList:(NSArray<NSString *> * _Nonnull)fieldList failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performRetrieveWithObjectType:objectId:fieldList:failBlock:completeBlock:")]
		SFRestRequest PerformRetrieveWithObjectType (string objectType, string objectId, string [] fieldList, SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performUpdateWithObjectType:(NSString * _Nonnull)objectType objectId:(NSString * _Nonnull)objectId fields:(NSDictionary<NSString *,id> * _Nonnull)fields failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performUpdateWithObjectType:objectId:fields:failBlock:completeBlock:")]
		SFRestRequest PerformUpdateWithObjectType (string objectType, string objectId, NSDictionary<NSString, NSObject> fields, SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performUpsertWithObjectType:(NSString * _Nonnull)objectType externalIdField:(NSString * _Nonnull)externalIdField externalId:(NSString * _Nonnull)externalId fields:(NSDictionary<NSString *,id> * _Nonnull)fields failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performUpsertWithObjectType:externalIdField:externalId:fields:failBlock:completeBlock:")]
		SFRestRequest PerformUpsertWithObjectType (string objectType, string externalIdField, string externalId, NSDictionary<NSString, NSObject> fields, SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performDeleteWithObjectType:(NSString * _Nonnull)objectType objectId:(NSString * _Nonnull)objectId failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performDeleteWithObjectType:objectId:failBlock:completeBlock:")]
		SFRestRequest PerformDeleteWithObjectType (string objectType, string objectId, SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performCreateWithObjectType:(NSString * _Nonnull)objectType fields:(NSDictionary<NSString *,id> * _Nonnull)fields failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performCreateWithObjectType:fields:failBlock:completeBlock:")]
		SFRestRequest PerformCreateWithObjectType (string objectType, NSDictionary<NSString, NSObject> fields, SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performRequestForResourcesWithFailBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performRequestForResourcesWithFailBlock:completeBlock:")]
		SFRestRequest PerformRequestForResourcesWithFailBlock (SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performRequestForVersionsWithFailBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performRequestForVersionsWithFailBlock:completeBlock:")]
		SFRestRequest PerformRequestForVersionsWithFailBlock (SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performRequestForFileRendition:(NSString * _Nonnull)sfdcId version:(NSString * _Nonnull)version renditionType:(NSString * _Nonnull)renditionType page:(NSUInteger)page failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDataResponseBlock _Nonnull)completeBlock;
		[Export ("performRequestForFileRendition:version:renditionType:page:failBlock:completeBlock:")]
		SFRestRequest PerformRequestForFileRendition (string sfdcId, string version, string renditionType, nuint page, SFRestFailBlock failBlock, SFRestDataResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performRequestForSearchScopeAndOrderWithFailBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestArrayResponseBlock _Nonnull)completeBlock;
		[Export ("performRequestForSearchScopeAndOrderWithFailBlock:completeBlock:")]
		SFRestRequest PerformRequestForSearchScopeAndOrderWithFailBlock (SFRestFailBlock failBlock, SFRestArrayResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performRequestForSearchResultLayout:(NSString * _Nonnull)objectList failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestArrayResponseBlock _Nonnull)completeBlock;
		[Export ("performRequestForSearchResultLayout:failBlock:completeBlock:")]
		SFRestRequest PerformRequestForSearchResultLayout (string objectList, SFRestFailBlock failBlock, SFRestArrayResponseBlock completeBlock);

		// -(SFRestRequest * _Nonnull)performRequestWithMethod:(SFRestMethod)method path:(NSString * _Nonnull)path queryParams:(NSDictionary<NSString *,id> * _Nonnull)queryParams failBlock:(SFRestFailBlock _Nonnull)failBlock completeBlock:(SFRestDictionaryResponseBlock _Nonnull)completeBlock;
		[Export ("performRequestWithMethod:path:queryParams:failBlock:completeBlock:")]
		SFRestRequest PerformRequestWithMethod (SFRestMethod method, string path, NSDictionary<NSString, NSObject> queryParams, SFRestFailBlock failBlock, SFRestDictionaryResponseBlock completeBlock);
	}

	// typedef void (^SFRestFailBlock)(NSError * _Nullable);
	delegate void SFRestFailBlock ([NullAllowed] NSError arg0);

	// typedef void (^SFRestDictionaryResponseBlock)(NSDictionary * _Nullable);
	delegate void SFRestDictionaryResponseBlock ([NullAllowed] NSDictionary arg0);

	// typedef void (^SFRestArrayResponseBlock)(NSArray * _Nullable);
	delegate void SFRestArrayResponseBlock ([NullAllowed] NSObject [] arg0);

	// typedef void (^SFRestDataResponseBlock)(NSData * _Nullable);
	delegate void SFRestDataResponseBlock ([NullAllowed] NSData arg0);

	// typedef void (^SFRestResponseBlock)(id _Nullable);
	delegate void SFRestResponseBlock ([NullAllowed] NSObject arg0);

	// @interface Files (SFRestAPI) <SFRestDelegate>
	[Category]
	[BaseType (typeof (SFRestAPI))]
	interface SFRestAPI_Files// : ISFRestDelegate
	{
		// -(SFRestRequest * _Nonnull)requestForOwnedFilesList:(NSString * _Nullable)userId page:(NSUInteger)page;
		[Export ("requestForOwnedFilesList:page:")]
		SFRestRequest RequestForOwnedFilesList ([NullAllowed] string userId, nuint page);

		// -(SFRestRequest * _Nonnull)requestForFilesInUsersGroups:(NSString * _Nullable)userId page:(NSUInteger)page;
		[Export ("requestForFilesInUsersGroups:page:")]
		SFRestRequest RequestForFilesInUsersGroups ([NullAllowed] string userId, nuint page);

		// -(SFRestRequest * _Nonnull)requestForFilesSharedWithUser:(NSString * _Nullable)userId page:(NSUInteger)page;
		[Export ("requestForFilesSharedWithUser:page:")]
		SFRestRequest RequestForFilesSharedWithUser ([NullAllowed] string userId, nuint page);

		// -(SFRestRequest * _Nonnull)requestForFileDetails:(NSString * _Nonnull)sfdcId forVersion:(NSString * _Nullable)version;
		[Export ("requestForFileDetails:forVersion:")]
		SFRestRequest RequestForFileDetails (string sfdcId, [NullAllowed] string version);

		// -(SFRestRequest * _Nonnull)requestForBatchFileDetails:(NSArray<NSString *> * _Nonnull)sfdcIds;
		[Export ("requestForBatchFileDetails:")]
		SFRestRequest RequestForBatchFileDetails (string [] sfdcIds);

		// -(SFRestRequest * _Nonnull)requestForFileRendition:(NSString * _Nonnull)sfdcId version:(NSString * _Nullable)version renditionType:(NSString * _Nonnull)renditionType page:(NSUInteger)page;
		[Export ("requestForFileRendition:version:renditionType:page:")]
		SFRestRequest RequestForFileRendition (string sfdcId, [NullAllowed] string version, string renditionType, nuint page);

		// -(SFRestRequest * _Nonnull)requestForFileContents:(NSString * _Nonnull)sfdcId version:(NSString * _Nullable)version;
		[Export ("requestForFileContents:version:")]
		SFRestRequest RequestForFileContents (string sfdcId, [NullAllowed] string version);

		// -(SFRestRequest * _Nonnull)requestForFileShares:(NSString * _Nonnull)sfdcId page:(NSUInteger)page;
		[Export ("requestForFileShares:page:")]
		SFRestRequest RequestForFileShares (string sfdcId, nuint page);

		// -(SFRestRequest * _Nonnull)requestForAddFileShare:(NSString * _Nonnull)fileId entityId:(NSString * _Nonnull)entityId shareType:(NSString * _Nonnull)shareType;
		[Export ("requestForAddFileShare:entityId:shareType:")]
		SFRestRequest RequestForAddFileShare (string fileId, string entityId, string shareType);

		// -(SFRestRequest * _Nonnull)requestForDeleteFileShare:(NSString * _Nonnull)shareId;
		[Export ("requestForDeleteFileShare:")]
		SFRestRequest RequestForDeleteFileShare (string shareId);

		// -(SFRestRequest * _Nonnull)requestForUploadFile:(NSData * _Nonnull)data name:(NSString * _Nonnull)name description:(NSString * _Nonnull)description mimeType:(NSString * _Nonnull)mimeType;
		[Export ("requestForUploadFile:name:description:mimeType:")]
		SFRestRequest RequestForUploadFile (NSData data, string name, string description, string mimeType);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kSOSLReservedCharacters;
		[Field ("kSOSLReservedCharacters", "__Internal")]
		NSString kSOSLReservedCharacters { get; }

		// extern NSString *const _Nonnull kSOSLEscapeCharacter;
		[Field ("kSOSLEscapeCharacter", "__Internal")]
		NSString kSOSLEscapeCharacter { get; }

		// extern const NSInteger kMaxSOSLSearchLimit;
		[Field ("kMaxSOSLSearchLimit", "__Internal")]
		nint kMaxSOSLSearchLimit { get; }
	}

	// @interface QueryBuilder (SFRestAPI)
	[Category]
	[BaseType (typeof (SFRestAPI))]
	interface SFRestAPI_QueryBuilder
	{
		// +(NSString * _Nonnull)sanitizeSOSLSearchTerm:(NSString * _Nonnull)searchTerm;
		[Static]
		[Export ("sanitizeSOSLSearchTerm:")]
		string SanitizeSOSLSearchTerm (string searchTerm);

		// +(NSString * _Nullable)SOSLSearchWithSearchTerm:(NSString * _Nonnull)term objectScope:(NSDictionary<NSString *,NSString *> * _Nullable)objectScope;
		[Static]
		[Export ("SOSLSearchWithSearchTerm:objectScope:")]
		[return: NullAllowed]
		string SOSLSearchWithSearchTerm (string term, [NullAllowed] NSDictionary<NSString, NSString> objectScope);

		// +(NSString * _Nullable)SOSLSearchWithSearchTerm:(NSString * _Nonnull)term fieldScope:(NSString * _Nullable)fieldScope objectScope:(NSDictionary<NSString *,NSString *> * _Nullable)objectScope limit:(NSInteger)limit;
		[Static]
		[Export ("SOSLSearchWithSearchTerm:fieldScope:objectScope:limit:")]
		[return: NullAllowed]
		string SOSLSearchWithSearchTerm (string term, [NullAllowed] string fieldScope, [NullAllowed] NSDictionary<NSString, NSString> objectScope, nint limit);

		// +(NSString * _Nullable)SOQLQueryWithFields:(NSArray<NSString *> * _Nonnull)fields sObject:(NSString * _Nonnull)sObject whereClause:(NSString * _Nullable)whereClause limit:(NSInteger)limit;
		[Static]
		[Export ("SOQLQueryWithFields:sObject:whereClause:limit:")]
		[return: NullAllowed]
		string SOQLQueryWithFields (string [] fields, string sObject, [NullAllowed] string whereClause, nint limit);

		// +(NSString * _Nullable)SOQLQueryWithFields:(NSArray<NSString *> * _Nonnull)fields sObject:(NSString * _Nonnull)sObject whereClause:(NSString * _Nullable)whereClause groupBy:(NSArray<NSString *> * _Nullable)groupBy having:(NSString * _Nullable)having orderBy:(NSArray<NSString *> * _Nullable)orderBy limit:(NSInteger)limit;
		[Static]
		[Export ("SOQLQueryWithFields:sObject:whereClause:groupBy:having:orderBy:limit:")]
		[return: NullAllowed]
		string SOQLQueryWithFields (string [] fields, string sObject, [NullAllowed] string whereClause, [NullAllowed] string [] groupBy, [NullAllowed] string having, [NullAllowed] string [] orderBy, nint limit);
	}

	// @interface SFRestAPISalesforceAction : CSFSalesforceAction
	[BaseType (typeof (CSFSalesforceAction))]
	interface SFRestAPISalesforceAction
	{
		// @property (assign, nonatomic) BOOL parseResponse;
		[Export ("parseResponse")]
		bool ParseResponse { get; set; }
	}

	// @protocol SFRootViewManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface SFRootViewManagerDelegate
	{
		// @optional -(void)rootViewManager:(SFRootViewManager *)manager willPushViewControler:(UIViewController *)viewController;
		[Export ("rootViewManager:willPushViewControler:")]
		void WillPushViewControler (SFRootViewManager manager, UIViewController viewController);

		// @optional -(void)rootViewManager:(SFRootViewManager *)manager didPopViewControler:(UIViewController *)viewController;
		[Export ("rootViewManager:didPopViewControler:")]
		void DidPopViewControler (SFRootViewManager manager, UIViewController viewController);
	}

	// @interface SFRootViewManager : NSObject
	[BaseType (typeof (NSObject))]
	interface SFRootViewManager
	{
		// +(SFRootViewManager *)sharedManager;
		[Static]
		[Export ("sharedManager")]
		//[Verify (MethodToProperty)]
		SFRootViewManager SharedManager { get; }

		// @property (nonatomic, strong) UIWindow * mainWindow;
		[Export ("mainWindow", ArgumentSemantic.Strong)]
		UIWindow MainWindow { get; set; }

		// -(void)addDelegate:(id<SFRootViewManagerDelegate>)delegate;
		[Export ("addDelegate:")]
		void AddDelegate (SFRootViewManagerDelegate @delegate);

		// -(void)removeDelegate:(id<SFRootViewManagerDelegate>)delegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (SFRootViewManagerDelegate @delegate);

		// -(void)pushViewController:(UIViewController *)viewController;
		[Export ("pushViewController:")]
		void PushViewController (UIViewController viewController);

		// -(void)popViewController:(UIViewController *)viewController;
		[Export ("popViewController:")]
		void PopViewController (UIViewController viewController);
	}

	// PART OF SALESFORCEANALYTICS
	// @protocol SFSDKAnalyticsPublisher <NSObject>
	//[Protocol, Model]
	//[BaseType (typeof (NSObject))]
	//interface ISFSDKAnalyticsPublisher
	//{
	//	// @required -(void)publish:(NSArray * _Nonnull)events publishCompleteBlock:(PublishCompleteBlock _Nonnull)publishCompleteBlock;
	//	[Abstract]
	//	[Export ("publish:publishCompleteBlock:")]
	//	[Verify (StronglyTypedNSArray)]
	//	void PublishCompleteBlock (NSObject [] events, PublishCompleteBlock publishCompleteBlock);
	//}

	// typedef void (^ _Nonnull)(BOOL, NSError * _Nullable) PublishCompleteBlock;
	//delegate void PublishCompleteBlock (bool arg0, [NullAllowed] NSError arg1);

	// @interface SFSDKAILTNPublisher : NSObject <SFSDKAnalyticsPublisher>
	//[BaseType (typeof (NSObject))]
	//interface SFSDKAILTNPublisher : ISFSDKAnalyticsPublisher
	//{
	//}

	// @interface SFSDKAppConfig : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKAppConfig
	{
		// @property (copy, nonatomic) NSString * remoteAccessConsumerKey;
		[Export ("remoteAccessConsumerKey")]
		string RemoteAccessConsumerKey { get; set; }

		// @property (copy, nonatomic) NSString * oauthRedirectURI;
		[Export ("oauthRedirectURI")]
		string OauthRedirectURI { get; set; }

		// @property (nonatomic, strong) NSSet * oauthScopes;
		[Export ("oauthScopes", ArgumentSemantic.Strong)]
		NSSet OauthScopes { get; set; }

		// @property (assign, nonatomic) BOOL shouldAuthenticate;
		[Export ("shouldAuthenticate")]
		bool ShouldAuthenticate { get; set; }

		// @property (nonatomic, strong) NSMutableDictionary * configDict;
		[Export ("configDict", ArgumentSemantic.Strong)]
		NSMutableDictionary ConfigDict { get; set; }

		// -(instancetype)initWithDict:(NSDictionary *)configDict;
		[Export ("initWithDict:")]
		IntPtr Constructor (NSDictionary configDict);
	}

	// @protocol SFSDKAppDelegate <UIApplicationDelegate>
	[Protocol, Model]
	interface SFSDKAppDelegate : IUIApplicationDelegate
	{
		// @required @property (readonly, nonatomic) NSString * userAgentString;
		[Abstract]
		[Export ("userAgentString")]
		string UserAgentString { get; }

		// @required -(void)logout;
		[Abstract]
		[Export ("logout")]
		void Logout ();

		// @required -(UIView *)createSnapshotView;
		[Abstract]
		[Export ("createSnapshotView")]
		//[Verify (MethodToProperty)]
		UIView CreateSnapshotView ();// { get; }
	}

	// @interface SFSDKAsyncProcessListener : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKAsyncProcessListener
	{
		// -(id)initWithExpectedStatus:(id)expectedStatus actualStatusBlock:(id (^)(void))actualStatusBlock timeout:(NSTimeInterval)timeout;
		[Export ("initWithExpectedStatus:actualStatusBlock:timeout:")]
		IntPtr Constructor (NSObject expectedStatus, Func<NSObject> actualStatusBlock, double timeout);

		// -(id)waitForCompletion;
		[Export ("waitForCompletion")]
		//[Verify (MethodToProperty)]
		NSObject WaitForCompletion ();// { get; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const NSUInteger kSFPBKDFDefaultNumberOfDerivationRounds;
		[Field ("kSFPBKDFDefaultNumberOfDerivationRounds", "__Internal")]
		nuint kSFPBKDFDefaultNumberOfDerivationRounds { get; }

		// extern const NSUInteger kSFPBKDFDefaultDerivedKeyByteLength;
		[Field ("kSFPBKDFDefaultDerivedKeyByteLength", "__Internal")]
		nuint kSFPBKDFDefaultDerivedKeyByteLength { get; }

		// extern const NSUInteger kSFPBKDFDefaultSaltByteLength;
		[Field ("kSFPBKDFDefaultSaltByteLength", "__Internal")]
		nuint kSFPBKDFDefaultSaltByteLength { get; }
	}

	// @interface SFSDKCryptoUtils : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKCryptoUtils
	{
		// +(NSData *)randomByteDataWithLength:(NSUInteger)lengthInBytes;
		[Static]
		[Export ("randomByteDataWithLength:")]
		NSData RandomByteDataWithLength (nuint lengthInBytes);

		// +(SFPBKDFData *)createPBKDF2DerivedKey:(NSString *)stringToHash;
		[Static]
		[Export ("createPBKDF2DerivedKey:")]
		SFPBKDFData CreatePBKDF2DerivedKey (string stringToHash);

		// +(SFPBKDFData *)createPBKDF2DerivedKey:(NSString *)stringToHash salt:(NSData *)salt derivationRounds:(NSUInteger)numDerivationRounds keyLength:(NSUInteger)derivedKeyLength;
		[Static]
		[Export ("createPBKDF2DerivedKey:salt:derivationRounds:keyLength:")]
		SFPBKDFData CreatePBKDF2DerivedKey (string stringToHash, NSData salt, nuint numDerivationRounds, nuint derivedKeyLength);

		// +(NSData *)aes256EncryptData:(NSData *)data withKey:(NSData *)key iv:(NSData *)iv;
		[Static]
		[Export ("aes256EncryptData:withKey:iv:")]
		NSData Aes256EncryptData (NSData data, NSData key, NSData iv);

		// +(NSData *)aes256DecryptData:(NSData *)data withKey:(NSData *)key iv:(NSData *)iv;
		[Static]
		[Export ("aes256DecryptData:withKey:iv:")]
		NSData Aes256DecryptData (NSData data, NSData key, NSData iv);
	}

	// @interface SFSDKDatasharingHelper : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKDatasharingHelper
	{
		// @property (nonatomic) BOOL appGroupEnabled;
		[Export ("appGroupEnabled")]
		bool AppGroupEnabled { get; set; }

		// @property (nonatomic) BOOL keychainSharingEnabled;
		[Export ("keychainSharingEnabled")]
		bool KeychainSharingEnabled { get; set; }

		// @property (nonatomic, strong) NSString * appGroupName;
		[Export ("appGroupName", ArgumentSemantic.Strong)]
		string AppGroupName { get; set; }

		// @property (nonatomic, strong) NSString * keychainGroupName;
		[Export ("keychainGroupName", ArgumentSemantic.Strong)]
		string KeychainGroupName { get; set; }

		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		SFSDKDatasharingHelper SharedInstance ();
	}

	// @interface SFSDKEventBuilderHelper : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKEventBuilderHelper
	{
		// +(void)createAndStoreEvent:(NSString * _Nonnull)name userAccount:(SFUserAccount * _Nullable)userAccount className:(NSString * _Nonnull)className attributes:(NSDictionary * _Nullable)attributes;
		[Static]
		[Export ("createAndStoreEvent:userAccount:className:attributes:")]
		void CreateAndStoreEvent (string name, [NullAllowed] SFUserAccount userAccount, string className, [NullAllowed] NSDictionary attributes);
	}

	// @interface SFSDKLoginHost : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKLoginHost
	{
		// @property (copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * host;
		[Export ("host")]
		string Host { get; set; }

		// @property (readonly, getter = isDeletable) BOOL deletable;
		[Export ("deletable")]
		bool Deletable { [Bind ("isDeletable")] get; }

		// +(SFSDKLoginHost *)hostWithName:(NSString *)name host:(NSString *)host deletable:(BOOL)deletable;
		[Static]
		[Export ("hostWithName:host:deletable:")]
		SFSDKLoginHost HostWithName (string name, string host, bool deletable);
	}

	// @protocol SFSDKLoginHostDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface SFSDKLoginHostDelegate
	{
		// @optional -(void)hostListViewController:(SFSDKLoginHostListViewController *)hostListViewController willPresentLoginHostViewController:(UIViewController *)loginHostViewController;
		[Export ("hostListViewController:willPresentLoginHostViewController:")]
		void HostListViewController (SFSDKLoginHostListViewController hostListViewController, UIViewController loginHostViewController);

		// @optional -(void)hostListViewControllerDidSelectLoginHost:(SFSDKLoginHostListViewController *)hostListViewController;
		[Export ("hostListViewControllerDidSelectLoginHost:")]
		void HostListViewControllerDidSelectLoginHost (SFSDKLoginHostListViewController hostListViewController);

		// @optional -(void)hostListViewControllerDidAddLoginHost:(SFSDKLoginHostListViewController *)hostListViewController;
		[Export ("hostListViewControllerDidAddLoginHost:")]
		void HostListViewControllerDidAddLoginHost (SFSDKLoginHostListViewController hostListViewController);

		// @optional -(void)hostListViewControllerDidCancelLoginHost:(SFSDKLoginHostListViewController *)hostListViewController;
		[Export ("hostListViewControllerDidCancelLoginHost:")]
		void HostListViewControllerDidCancelLoginHost (SFSDKLoginHostListViewController hostListViewController);
	}

	// @interface SFSDKLoginHostListViewController : UITableViewController
	[BaseType (typeof (UITableViewController))]
	interface SFSDKLoginHostListViewController
	{
		[Wrap ("WeakDelegate")]
		SFSDKLoginHostDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SFSDKLoginHostDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)addLoginHost:(SFSDKLoginHost *)host;
		[Export ("addLoginHost:")]
		void AddLoginHost (SFSDKLoginHost host);

		// -(void)showAddLoginHost;
		[Export ("showAddLoginHost")]
		void ShowAddLoginHost ();
	}

	// @interface SFSDKLoginHostStorage : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKLoginHostStorage
	{
		// +(SFSDKLoginHostStorage *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		//[Verify (MethodToProperty)]
		SFSDKLoginHostStorage SharedInstance { get; }

		// -(void)addLoginHost:(SFSDKLoginHost *)loginHost;
		[Export ("addLoginHost:")]
		void AddLoginHost (SFSDKLoginHost loginHost);

		// -(void)removeLoginHostAtIndex:(NSUInteger)index;
		[Export ("removeLoginHostAtIndex:")]
		void RemoveLoginHostAtIndex (nuint index);

		// -(NSUInteger)indexOfLoginHost:(SFSDKLoginHost *)host;
		[Export ("indexOfLoginHost:")]
		nuint IndexOfLoginHost (SFSDKLoginHost host);

		// -(SFSDKLoginHost *)loginHostAtIndex:(NSUInteger)index;
		[Export ("loginHostAtIndex:")]
		SFSDKLoginHost LoginHostAtIndex (nuint index);

		// -(SFSDKLoginHost *)loginHostForHostAddress:(NSString *)hostAddress;
		[Export ("loginHostForHostAddress:")]
		SFSDKLoginHost LoginHostForHostAddress (string hostAddress);

		// -(void)removeAllLoginHosts;
		[Export ("removeAllLoginHosts")]
		void RemoveAllLoginHosts ();

		// -(NSUInteger)numberOfLoginHosts;
		[Export ("numberOfLoginHosts")]
		//[Verify (MethodToProperty)]
		nuint NumberOfLoginHosts { get; }

		// -(void)save;
		[Export ("save")]
		void Save ();
	}

	// @interface SFSDKResourceUtils : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKResourceUtils
	{
		// +(NSBundle *)mainSdkBundle;
		[Static]
		[Export ("mainSdkBundle")]
		//[Verify (MethodToProperty)]
		NSBundle MainSdkBundle { get; }

		// +(NSString *)localizedString:(NSString *)localizationKey;
		[Static]
		[Export ("localizedString:")]
		string LocalizedString (string localizationKey);

		// +(UIImage *)imageNamed:(NSString *)name;
		[Static]
		[Export ("imageNamed:")]
		UIImage ImageNamed (string name);
	}

	// PART OF SALESFORCEANALYTICS
	// @interface SFSDKSalesforceAnalyticsManager : NSObject
	//[BaseType (typeof (NSObject))]
	//interface SFSDKSalesforceAnalyticsManager
	//{
	//	// @property (readonly, nonatomic, strong) SFSDKEventStoreManager * _Nonnull eventStoreManager;
	//	[Export ("eventStoreManager", ArgumentSemantic.Strong)]
	//	SFSDKEventStoreManager EventStoreManager { get; }

	//	// @property (readonly, nonatomic, strong) SFSDKAnalyticsManager * _Nonnull analyticsManager;
	//	[Export ("analyticsManager", ArgumentSemantic.Strong)]
	//	SFSDKAnalyticsManager AnalyticsManager { get; }

	//	// @property (readonly, nonatomic, strong) SFUserAccount * _Nonnull userAccount;
	//	[Export ("userAccount", ArgumentSemantic.Strong)]
	//	SFUserAccount UserAccount { get; }

	//	// @property (getter = isLoggingEnabled, assign, readwrite, nonatomic) BOOL loggingEnabled;
	//	[Export ("loggingEnabled")]
	//	bool LoggingEnabled { [Bind ("isLoggingEnabled")] get; set; }

	//	// +(instancetype _Nonnull)sharedInstanceWithUser:(SFUserAccount * _Nonnull)userAccount;
	//	[Static]
	//	[Export ("sharedInstanceWithUser:")]
	//	SFSDKSalesforceAnalyticsManager SharedInstanceWithUser (SFUserAccount userAccount);

	//	// +(void)removeSharedInstanceWithUser:(SFUserAccount * _Nonnull)userAccount;
	//	[Static]
	//	[Export ("removeSharedInstanceWithUser:")]
	//	void RemoveSharedInstanceWithUser (SFUserAccount userAccount);

	//	// -(void)publishAllEvents;
	//	[Export ("publishAllEvents")]
	//	void PublishAllEvents ();

	//	// -(void)publishEvents:(NSArray<SFSDKInstrumentationEvent *> * _Nonnull)events;
	//	[Export ("publishEvents:")]
	//	void PublishEvents (SFSDKInstrumentationEvent [] events);

	//	// -(void)publishEvent:(SFSDKInstrumentationEvent * _Nonnull)event;
	//	[Export ("publishEvent:")]
	//	void PublishEvent (SFSDKInstrumentationEvent @event);

	//	// -(void)addRemotePublisher:(id<SFSDKTransform> _Nonnull)transformer publisher:(id<SFSDKAnalyticsPublisher> _Nonnull)publisher;
	//	[Export ("addRemotePublisher:publisher:")]
	//	void AddRemotePublisher (SFSDKTransform transformer, ISFSDKAnalyticsPublisher publisher);

	//	// -(void)updateLoggingPrefs;
	//	[Export ("updateLoggingPrefs")]
	//	void UpdateLoggingPrefs ();
	//}

	// @interface SFSDKTestCredentialsData : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKTestCredentialsData
	{
		// -(id)initWithDict:(NSDictionary *)credentialsDict;
		[Export ("initWithDict:")]
		IntPtr Constructor (NSDictionary credentialsDict);

		// @property (readonly, nonatomic) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, nonatomic) NSString * refreshToken;
		[Export ("refreshToken")]
		string RefreshToken { get; }

		// @property (readonly, nonatomic) NSString * identityUrl;
		[Export ("identityUrl")]
		string IdentityUrl { get; }

		// @property (readonly, nonatomic) NSString * instanceUrl;
		[Export ("instanceUrl")]
		string InstanceUrl { get; }

		// @property (readonly, nonatomic) NSString * clientId;
		[Export ("clientId")]
		string ClientId { get; }

		// @property (readonly, nonatomic) NSString * redirectUri;
		[Export ("redirectUri")]
		string RedirectUri { get; }

		// @property (readonly, nonatomic) NSString * loginHost;
		[Export ("loginHost")]
		string LoginHost { get; }

		// @property (readonly, nonatomic) NSString * communityUrl;
		[Export ("communityUrl")]
		string CommunityUrl { get; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kTestRequestStatusWaiting;
		[Field ("kTestRequestStatusWaiting", "__Internal")]
		NSString kTestRequestStatusWaiting { get; }

		// extern NSString *const kTestRequestStatusDidLoad;
		[Field ("kTestRequestStatusDidLoad", "__Internal")]
		NSString kTestRequestStatusDidLoad { get; }

		// extern NSString *const kTestRequestStatusDidFail;
		[Field ("kTestRequestStatusDidFail", "__Internal")]
		NSString kTestRequestStatusDidFail { get; }

		// extern NSString *const kTestRequestStatusDidCancel;
		[Field ("kTestRequestStatusDidCancel", "__Internal")]
		NSString kTestRequestStatusDidCancel { get; }

		// extern NSString *const kTestRequestStatusDidTimeout;
		[Field ("kTestRequestStatusDidTimeout", "__Internal")]
		NSString kTestRequestStatusDidTimeout { get; }
	}

	// @interface SFSDKTestRequestListener : NSObject <SFIdentityCoordinatorDelegate, SFOAuthCoordinatorDelegate>
	[BaseType (typeof (NSObject))]
	interface SFSDKTestRequestListener : ISFIdentityCoordinatorDelegate, ISFOAuthCoordinatorDelegate
	{
		// @property (retain, nonatomic) id dataResponse;
		[Export ("dataResponse", ArgumentSemantic.Retain)]
		NSObject DataResponse { get; set; }

		// @property (retain, nonatomic) NSError * lastError;
		[Export ("lastError", ArgumentSemantic.Retain)]
		NSError LastError { get; set; }

		// @property (retain, nonatomic) NSString * returnStatus;
		[Export ("returnStatus", ArgumentSemantic.Retain)]
		string ReturnStatus { get; set; }

		// @property (assign, nonatomic) NSTimeInterval maxWaitTime;
		[Export ("maxWaitTime")]
		double MaxWaitTime { get; set; }

		// -(id)initWithServiceType:(SFAccountManagerServiceType)serviceType;
		[Export ("initWithServiceType:")]
		IntPtr Constructor (SFAccountManagerServiceType serviceType);

		// -(NSString *)waitForCompletion;
		[Export ("waitForCompletion")]
		//[Verify (MethodToProperty)]
		string WaitForCompletion ();// { get; }

		// -(NSString *)serviceTypeDescription;
		[Export ("serviceTypeDescription")]
		//[Verify (MethodToProperty)]
		string ServiceTypeDescription { get; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kUserAgentPropKey;
		[Field ("kUserAgentPropKey", "__Internal")]
		NSString kUserAgentPropKey { get; }
	}

	// @interface SFSDKWebUtils : NSObject
	[BaseType (typeof (NSObject))]
	interface SFSDKWebUtils
	{
		// +(void)configureUserAgent:(NSString *)userAgentString;
		[Static]
		[Export ("configureUserAgent:")]
		void ConfigureUserAgent (string userAgentString);
	}

	// @interface  (SFSecurityLockout)
	[Category]
	[BaseType (typeof (SFSecurityLockout))]
	interface SFSecurityLockout_
	{
		// +(void)timerExpired:(NSTimer *)theTimer;
		[Static]
		[Export ("timerExpired:")]
		void TimerExpired (NSTimer theTimer);

		// +(void)presentPasscodeController:(SFPasscodeControllerMode)modeValue passcodeConfig:(SFPasscodeConfigurationData)configData;
		[Static]
		[Export ("presentPasscodeController:passcodeConfig:")]
		void PresentPasscodeController (SFPasscodeControllerMode modeValue, SFPasscodeConfigurationData configData);

		// +(UIViewController *)passcodeViewController;
		// +(void)setPasscodeViewController:(UIViewController *)vc;
		[Static]
		[Export ("passcodeViewController")]
		//[Verify (MethodToProperty)]
		UIViewController PasscodeViewController { get; set; }

		// +(BOOL)passcodeScreenIsPresent;
		[Static]
		[Export ("passcodeScreenIsPresent")]
		//[Verify (MethodToProperty)]
		bool PasscodeScreenIsPresent { get; }

		// +(void)cancelPasscodeScreen;
		[Static]
		[Export ("cancelPasscodeScreen")]
		void CancelPasscodeScreen ();

		// +(BOOL)hasValidSession;
		[Static]
		[Export ("hasValidSession")]
		//[Verify (MethodToProperty)]
		bool HasValidSession { get; }

		// +(void)unlockSuccessPostProcessing:(SFSecurityLockoutAction)action;
		[Static]
		[Export ("unlockSuccessPostProcessing:")]
		void UnlockSuccessPostProcessing (SFSecurityLockoutAction action);

		// +(void)unlockFailurePostProcessing;
		[Static]
		[Export ("unlockFailurePostProcessing")]
		void UnlockFailurePostProcessing ();

		// +(void)sendPasscodeFlowWillBeginNotification:(SFPasscodeControllerMode)mode;
		[Static]
		[Export ("sendPasscodeFlowWillBeginNotification:")]
		void SendPasscodeFlowWillBeginNotification (SFPasscodeControllerMode mode);

		// +(void)sendPasscodeFlowCompletedNotification:(BOOL)validationSuccess;
		[Static]
		[Export ("sendPasscodeFlowCompletedNotification:")]
		void SendPasscodeFlowCompletedNotification (bool validationSuccess);

		// +(void)setLockoutTimeInternal:(NSUInteger)seconds;
		[Static]
		[Export ("setLockoutTimeInternal:")]
		void SetLockoutTimeInternal (nuint seconds);

		// +(NSNumber *)readLockoutTimeFromKeychain;
		[Static]
		[Export ("readLockoutTimeFromKeychain")]
		//[Verify (MethodToProperty)]
		NSNumber ReadLockoutTimeFromKeychain ();// { get; }

		// +(void)writeLockoutTimeToKeychain:(NSNumber *)lockoutTime;
		[Static]
		[Export ("writeLockoutTimeToKeychain:")]
		void WriteLockoutTimeToKeychain (NSNumber lockoutTime);

		// +(NSNumber *)readIsLockedFromKeychain;
		[Static]
		[Export ("readIsLockedFromKeychain")]
		//[Verify (MethodToProperty)]
		NSNumber ReadIsLockedFromKeychain ();// { get; }

		// +(void)writeIsLockedToKeychain:(NSNumber *)locked;
		[Static]
		[Export ("writeIsLockedToKeychain:")]
		void WriteIsLockedToKeychain (NSNumber locked);

		// +(void)upgradeSettings;
		[Static]
		[Export ("upgradeSettings")]
		void UpgradeSettings ();

		// +(void)enumerateDelegates:(void (^)(id<SFSecurityLockoutDelegate>))block;
		[Static]
		[Export ("enumerateDelegates:")]
		void EnumerateDelegates (Action<SFSecurityLockoutDelegate> block);
	}

	// @interface SFSHA256PasscodeProvider : NSObject <SFPasscodeProvider>
	[BaseType (typeof (NSObject))]
	interface SFSHA256PasscodeProvider : ISFPasscodeProvider
	{
	}

	// @interface SFTestContext : NSObject
	[BaseType (typeof (NSObject))]
	interface SFTestContext
	{
		// +(BOOL)isRunningTests;
		// +(void)setIsRunningTests:(BOOL)runningTests;
		[Static]
		[Export ("isRunningTests")]
		//[Verify (MethodToProperty)]
		bool IsRunningTests { get; set; }

		// +(void)setObject:(id)object forKey:(id)key;
		[Static]
		[Export ("setObject:forKey:")]
		void SetObject (NSObject @object, NSObject key);

		// +(id)objectForKey:(id)key;
		[Static]
		[Export ("objectForKey:")]
		NSObject ObjectForKey (NSObject key);

		// +(void)clearObjects;
		[Static]
		[Export ("clearObjects")]
		void ClearObjects ();
	}

	// @interface SalesforceNetwork (SFUserAccount)
	[Category]
	[BaseType (typeof (SFUserAccount))]
	interface SFUserAccount_SalesforceNetwork
	{
		// @property (readonly, nonatomic, strong) CSFNetwork * network;
		[Static]
		[Export ("network", ArgumentSemantic.Strong)]
		CSFNetwork Network { get; }
	}

	// @interface SFUserAccountManagerUpgrade : NSObject
	[BaseType (typeof (NSObject))]
	interface SFUserAccountManagerUpgrade
	{
		// +(SFUserAccount *)createUserFromLegacyAccountData;
		[Static]
		[Export ("createUserFromLegacyAccountData")]
		//[Verify (MethodToProperty)]
		SFUserAccount CreateUserFromLegacyAccountData ();// { get; }

		// +(void)updateToActiveUserIdentity:(SFUserAccountManager *)accountManager;
		[Static]
		[Export ("updateToActiveUserIdentity:")]
		void UpdateToActiveUserIdentity (SFUserAccountManager accountManager);
	}

	// @interface SFUserActivityMonitor : NSObject
	[BaseType (typeof (NSObject))]
	interface SFUserActivityMonitor
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		SFUserActivityMonitor SharedInstance ();

		// -(void)startMonitoring;
		[Export ("startMonitoring")]
		void StartMonitoring ();

		// -(void)stopMonitoring;
		[Export ("stopMonitoring")]
		void StopMonitoring ();
	}

	// @interface TestSetupUtils : NSObject
	[BaseType (typeof (NSObject))]
	interface TestSetupUtils
	{
		// +(NSArray *)populateUILoginInfoFromConfigFileForClass:(Class)testClass;
		[Static]
		[Export ("populateUILoginInfoFromConfigFileForClass:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject [] PopulateUILoginInfoFromConfigFileForClass (Class testClass);

		// +(SFSDKTestCredentialsData *)populateAuthCredentialsFromConfigFileForClass:(Class)testClass;
		[Static]
		[Export ("populateAuthCredentialsFromConfigFileForClass:")]
		SFSDKTestCredentialsData PopulateAuthCredentialsFromConfigFileForClass (Class testClass);

		// +(void)synchronousAuthRefresh;
		[Static]
		[Export ("synchronousAuthRefresh")]
		void SynchronousAuthRefresh ();
	}

	// @interface SFColors (UIColor)
	[Category]
	[BaseType (typeof (UIColor))]
	interface UIColor_SFColors
	{
		// +(UIColor *)salesforceBlueColor;
		[Static]
		[Export ("salesforceBlueColor")]
		//[Verify (MethodToProperty)]
		UIColor SalesforceBlueColor { get; }

		// +(UIColor *)colorFromHexValue:(NSString *)hexString;
		[Static]
		[Export ("colorFromHexValue:")]
		UIColor ColorFromHexValue (string hexString);

		// -(NSString *)hexStringFromColor;
		[Static]
		[Export ("hexStringFromColor")]
		//[Verify (MethodToProperty)]
		string HexStringFromColor { get; }
	}

	// @interface SFHardware (UIDevice)
	[Category]
	[BaseType (typeof (UIDevice))]
	interface UIDevice_SFHardware
	{
		// -(NSString *)platform;
		[Static]
		[Export ("platform")]
		//[Verify (MethodToProperty)]
		string Platform { get; }

		// -(NSString *)hwmodel;
		[Static]
		[Export ("hwmodel")]
		//[Verify (MethodToProperty)]
		string Hwmodel { get; }

		// -(UIDevicePlatform)platformType;
		[Static]
		[Export ("platformType")]
		//[Verify (MethodToProperty)]
		UIDevicePlatform PlatformType { get; }

		// -(double)systemVersionNumber;
		[Static]
		[Export ("systemVersionNumber")]
		//[Verify (MethodToProperty)]
		double SystemVersionNumber { get; }

		// -(NSString *)platformString;
		[Static]
		[Export ("platformString")]
		//[Verify (MethodToProperty)]
		string PlatformString { get; }

		// -(NSUInteger)cpuFrequency;
		[Static]
		[Export ("cpuFrequency")]
		//[Verify (MethodToProperty)]
		nuint CpuFrequency { get; }

		// -(NSUInteger)busFrequency;
		[Static]
		[Export ("busFrequency")]
		//[Verify (MethodToProperty)]
		nuint BusFrequency { get; }

		// -(NSUInteger)cpuCount;
		[Static]
		[Export ("cpuCount")]
		//[Verify (MethodToProperty)]
		nuint CpuCount { get; }

		// -(float)totalCPU;
		[Static]
		[Export ("totalCPU")]
		//[Verify (MethodToProperty)]
		float TotalCPU { get; }

		// -(NSUInteger)totalMemory;
		[Static]
		[Export ("totalMemory")]
		//[Verify (MethodToProperty)]
		nuint TotalMemory { get; }

		// -(NSUInteger)userMemory;
		[Static]
		[Export ("userMemory")]
		//[Verify (MethodToProperty)]
		nuint UserMemory { get; }

		// -(NSUInteger)applicationMemory;
		[Static]
		[Export ("applicationMemory")]
		//[Verify (MethodToProperty)]
		nuint ApplicationMemory { get; }

		// -(NSUInteger)freeMemory;
		[Static]
		[Export ("freeMemory")]
		//[Verify (MethodToProperty)]
		nuint FreeMemory { get; }

		// -(NSNumber *)totalDiskSpace;
		[Static]
		[Export ("totalDiskSpace")]
		//[Verify (MethodToProperty)]
		NSNumber TotalDiskSpace { get; }

		// -(NSNumber *)freeDiskSpace;
		[Static]
		[Export ("freeDiskSpace")]
		//[Verify (MethodToProperty)]
		NSNumber FreeDiskSpace { get; }

		// -(NSString *)macaddress;
		[Static]
		[Export ("macaddress")]
		//[Verify (MethodToProperty)]
		string Macaddress { get; }

		// -(BOOL)hasRetinaDisplay;
		[Static]
		[Export ("hasRetinaDisplay")]
		//[Verify (MethodToProperty)]
		bool HasRetinaDisplay { get; }

		// -(UIDeviceFamily)deviceFamily;
		[Static]
		[Export ("deviceFamily")]
		//[Verify (MethodToProperty)]
		UIDeviceFamily DeviceFamily { get; }

		// -(UIInterfaceOrientation)interfaceOrientation;
		[Static]
		[Export ("interfaceOrientation")]
		//[Verify (MethodToProperty)]
		UIInterfaceOrientation InterfaceOrientation { get; }

		// -(BOOL)isSimulator;
		[Static]
		[Export ("isSimulator")]
		//[Verify (MethodToProperty)]
		bool IsSimulator { get; }

		// -(BOOL)canDevicePlaceAPhoneCall;
		[Static]
		[Export ("canDevicePlaceAPhoneCall")]
		//[Verify (MethodToProperty)]
		bool CanDevicePlaceAPhoneCall { get; }

		// -(BOOL)hasIphone6ScreenSize;
		[Static]
		[Export ("hasIphone6ScreenSize")]
		//[Verify (MethodToProperty)]
		bool HasIphone6ScreenSize { get; }

		// -(BOOL)hasIphone6PlusScreenSize;
		[Static]
		[Export ("hasIphone6PlusScreenSize")]
		//[Verify (MethodToProperty)]
		bool HasIphone6PlusScreenSize { get; }

		// +(BOOL)currentDeviceIsIPad;
		[Static]
		[Export ("currentDeviceIsIPad")]
		//[Verify (MethodToProperty)]
		bool CurrentDeviceIsIPad { get; }

		// +(BOOL)currentDeviceIsIPhone;
		[Static]
		[Export ("currentDeviceIsIPhone")]
		//[Verify (MethodToProperty)]
		bool CurrentDeviceIsIPhone { get; }
	}

	// @interface SFAdditions (UIScreen)
	[Category]
	[BaseType (typeof (UIScreen))]
	interface UIScreen_SFAdditions
	{
		// -(CGRect)portraitScreenBounds;
		[Static]
		[Export ("portraitScreenBounds")]
		//[Verify (MethodToProperty)]
		CGRect PortraitScreenBounds { get; }
	}

}
