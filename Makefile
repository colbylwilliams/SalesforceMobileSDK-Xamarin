IOS_PROJECT_ROOT=./extern/ios/SalesforceMobileSDK-iOS
IOS_PROJECT_BUILD=$(IOS_PROJECT_ROOT)/build
IOS_PROJECT_EXTERNAL=.$(IOS_PROJECT_ROOT)/external
IOS_PROJECT_ARTIFACTS=$(IOS_PROJECT_BUILD)/artifacts

IOS_BUILD=./build/ios
IOS_EXTRAS=./extras/ios

GRADLE=sh /Applications/Android\ Studio.app/Contents/gradle/gradle-2.14.1/bin/gradle
ANDROID_HOME=$(HOME)/Library/Developer/Xamarin/android-sdk-macosx



all : clean $(IOS_BUILD)/Release/SalesforceSDKCore.framework


$(IOS_PROJECT_ROOT)/install.sh :
	mkdir -p extern
	cd extern && mkdir -p ios
	cd extern/ios && git clone https://github.com/forcedotcom/SalesforceMobileSDK-iOS.git


$(IOS_PROJECT_EXTERNAL)/shared/README.md : $(IOS_PROJECT_ROOT)/install.sh
	cd $(IOS_PROJECT_ROOT) && ./install.sh


$(IOS_PROJECT_BUILD)/build-ios-sdk.sh : $(IOS_PROJECT_EXTERNAL)/shared/README.md
	cp -p $(IOS_EXTRAS)/build-ios-sdk.sh $(IOS_PROJECT_BUILD)
	cd $(IOS_PROJECT_BUILD) && chmod +x build-ios-sdk.sh


$(IOS_PROJECT_ARTIFACTS)/Release/SalesforceSDKCore.framework : $(IOS_PROJECT_BUILD)/build-ios-sdk.sh
	cd $(IOS_PROJECT_BUILD) && ./build-ios-sdk.sh


$(IOS_BUILD)/Release/SalesforceSDKCore.framework : $(IOS_PROJECT_ARTIFACTS)/Release/SalesforceSDKCore.framework
	mkdir -p build
	cd build && mkdir -p ios
	-mv $(IOS_PROJECT_ARTIFACTS)/Debug $(IOS_BUILD)
	-mv $(IOS_PROJECT_ARTIFACTS)/Release $(IOS_BUILD)


clean :
	rm -rf extern
	rm -rf build
