using System;
using Foundation;
using ObjCRuntime;
using OpenEars;

// @interface OEEventsObserver : NSObject
[BaseType (typeof(NSObject))]
interface OEEventsObserver
{
	[Wrap ("WeakDelegate")]
	OEEventsObserverDelegate Delegate { get; set; }

	// @property (weak) id<OEEventsObserverDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }
}

// @protocol OEEventsObserverDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface OEEventsObserverDelegate
{
	// @optional -(void)audioSessionInterruptionDidBegin;
	[Export ("audioSessionInterruptionDidBegin")]
	void AudioSessionInterruptionDidBegin ();

	// @optional -(void)audioSessionInterruptionDidEnd;
	[Export ("audioSessionInterruptionDidEnd")]
	void AudioSessionInterruptionDidEnd ();

	// @optional -(void)audioInputDidBecomeUnavailable;
	[Export ("audioInputDidBecomeUnavailable")]
	void AudioInputDidBecomeUnavailable ();

	// @optional -(void)audioInputDidBecomeAvailable;
	[Export ("audioInputDidBecomeAvailable")]
	void AudioInputDidBecomeAvailable ();

	// @optional -(void)audioRouteDidChangeToRoute:(NSString *)newRoute;
	[Export ("audioRouteDidChangeToRoute:")]
	void AudioRouteDidChangeToRoute (string newRoute);

	// @optional -(void)pocketsphinxRecognitionLoopDidStart;
	[Export ("pocketsphinxRecognitionLoopDidStart")]
	void PocketsphinxRecognitionLoopDidStart ();

	// @optional -(void)pocketsphinxDidStartListening;
	[Export ("pocketsphinxDidStartListening")]
	void PocketsphinxDidStartListening ();

	// @optional -(void)pocketsphinxDidDetectSpeech;
	[Export ("pocketsphinxDidDetectSpeech")]
	void PocketsphinxDidDetectSpeech ();

	// @optional -(void)pocketsphinxDidDetectFinishedSpeech;
	[Export ("pocketsphinxDidDetectFinishedSpeech")]
	void PocketsphinxDidDetectFinishedSpeech ();

	// @optional -(void)pocketsphinxDidReceiveHypothesis:(NSString *)hypothesis recognitionScore:(NSString *)recognitionScore utteranceID:(NSString *)utteranceID;
	[Export ("pocketsphinxDidReceiveHypothesis:recognitionScore:utteranceID:")]
	void PocketsphinxDidReceiveHypothesis (string hypothesis, string recognitionScore, string utteranceID);

	// @optional -(void)pocketsphinxDidReceiveNBestHypothesisArray:(NSArray *)hypothesisArray;
	[Export ("pocketsphinxDidReceiveNBestHypothesisArray:")]
	[Verify (StronglyTypedNSArray)]
	void PocketsphinxDidReceiveNBestHypothesisArray (NSObject[] hypothesisArray);

	// @optional -(void)pocketsphinxDidStopListening;
	[Export ("pocketsphinxDidStopListening")]
	void PocketsphinxDidStopListening ();

	// @optional -(void)pocketsphinxDidSuspendRecognition;
	[Export ("pocketsphinxDidSuspendRecognition")]
	void PocketsphinxDidSuspendRecognition ();

	// @optional -(void)pocketsphinxDidResumeRecognition;
	[Export ("pocketsphinxDidResumeRecognition")]
	void PocketsphinxDidResumeRecognition ();

	// @optional -(void)pocketsphinxDidChangeLanguageModelToFile:(NSString *)newLanguageModelPathAsString andDictionary:(NSString *)newDictionaryPathAsString;
	[Export ("pocketsphinxDidChangeLanguageModelToFile:andDictionary:")]
	void PocketsphinxDidChangeLanguageModelToFile (string newLanguageModelPathAsString, string newDictionaryPathAsString);

	// @optional -(void)pocketSphinxContinuousSetupDidFailWithReason:(NSString *)reasonForFailure;
	[Export ("pocketSphinxContinuousSetupDidFailWithReason:")]
	void PocketSphinxContinuousSetupDidFailWithReason (string reasonForFailure);

	// @optional -(void)pocketSphinxContinuousTeardownDidFailWithReason:(NSString *)reasonForFailure;
	[Export ("pocketSphinxContinuousTeardownDidFailWithReason:")]
	void PocketSphinxContinuousTeardownDidFailWithReason (string reasonForFailure);

	// @optional -(void)pocketsphinxTestRecognitionCompleted;
	[Export ("pocketsphinxTestRecognitionCompleted")]
	void PocketsphinxTestRecognitionCompleted ();

	// @optional -(void)pocketsphinxFailedNoMicPermissions;
	[Export ("pocketsphinxFailedNoMicPermissions")]
	void PocketsphinxFailedNoMicPermissions ();

	// @optional -(void)micPermissionCheckCompleted:(BOOL)result;
	[Export ("micPermissionCheckCompleted:")]
	void MicPermissionCheckCompleted (bool result);

	// @optional -(void)fliteDidStartSpeaking;
	[Export ("fliteDidStartSpeaking")]
	void FliteDidStartSpeaking ();

	// @optional -(void)fliteDidFinishSpeaking;
	[Export ("fliteDidFinishSpeaking")]
	void FliteDidFinishSpeaking ();
}

// @interface OEContinuousAudioUnit : NSObject
[BaseType (typeof(NSObject))]
interface OEContinuousAudioUnit
{
	// @property (copy, atomic) NSString * pathToTestFile;
	[Export ("pathToTestFile")]
	string PathToTestFile { get; set; }

	// @property (readonly, getter = getInputDecibels, atomic) float inputDecibels;
	[Export ("inputDecibels")]
	float InputDecibels { [Bind ("getInputDecibels")] get; }

	// @property (copy, nonatomic) NSString * audioMode;
	[Export ("audioMode")]
	string AudioMode { get; set; }

	// @property (assign, nonatomic) int audioUnitState;
	[Export ("audioUnitState")]
	int AudioUnitState { get; set; }

	// @property (assign, nonatomic) BOOL disableBluetooth;
	[Export ("disableBluetooth")]
	bool DisableBluetooth { get; set; }

	// @property (assign, nonatomic) BOOL disableMixing;
	[Export ("disableMixing")]
	bool DisableMixing { get; set; }

	// @property (assign, nonatomic) BOOL disablePreferredSampleRate;
	[Export ("disablePreferredSampleRate")]
	bool DisablePreferredSampleRate { get; set; }

	// @property (assign, nonatomic) BOOL disablePreferredBufferSize;
	[Export ("disablePreferredBufferSize")]
	bool DisablePreferredBufferSize { get; set; }

	// @property (assign, nonatomic) BOOL disablePreferredChannelNumber;
	[Export ("disablePreferredChannelNumber")]
	bool DisablePreferredChannelNumber { get; set; }

	// @property (assign, nonatomic) BOOL disableSessionResetsWhileStopped;
	[Export ("disableSessionResetsWhileStopped")]
	bool DisableSessionResetsWhileStopped { get; set; }

	// -(void)suspendRecognition;
	[Export ("suspendRecognition")]
	void SuspendRecognition ();

	// -(void)resumeRecognition;
	[Export ("resumeRecognition")]
	void ResumeRecognition ();

	// -(void)testFileChange;
	[Export ("testFileChange")]
	void TestFileChange ();

	// -(NSError *)startAudioUnit;
	[Export ("startAudioUnit")]
	[Verify (MethodToProperty)]
	NSError StartAudioUnit { get; }

	// -(NSError *)stopAudioUnit;
	[Export ("stopAudioUnit")]
	[Verify (MethodToProperty)]
	NSError StopAudioUnit { get; }

	// -(NSError *)setupAudioSession;
	[Export ("setupAudioSession")]
	[Verify (MethodToProperty)]
	NSError SetupAudioSession { get; }

	// -(NSError *)setupAudioUnit;
	[Export ("setupAudioUnit")]
	[Verify (MethodToProperty)]
	NSError SetupAudioUnit { get; }

	// -(NSString *)getCurrentRoute;
	[Export ("getCurrentRoute")]
	[Verify (MethodToProperty)]
	string CurrentRoute { get; }

	// -(NSError *)teardownAudioSession;
	[Export ("teardownAudioSession")]
	[Verify (MethodToProperty)]
	NSError TeardownAudioSession { get; }

	// -(NSError *)teardownAudioUnit;
	[Export ("teardownAudioUnit")]
	[Verify (MethodToProperty)]
	NSError TeardownAudioUnit { get; }
}

// @interface OESmartCMN : NSObject
[BaseType (typeof(NSObject))]
interface OESmartCMN
{
	// -(void)finalizeCmn:(float)cmnFloat atRoute:(NSString *)routeString forAcousticModelAtPath:(NSString *)acousticModelPath withModelName:(NSString *)modelName;
	[Export ("finalizeCmn:atRoute:forAcousticModelAtPath:withModelName:")]
	void FinalizeCmn (float cmnFloat, string routeString, string acousticModelPath, string modelName);

	// -(float)smartCmnValuesForRoute:(NSString *)routeString forAcousticModelAtPath:(NSString *)acousticModelPath withModelName:(NSString *)modelName;
	[Export ("smartCmnValuesForRoute:forAcousticModelAtPath:withModelName:")]
	float SmartCmnValuesForRoute (string routeString, string acousticModelPath, string modelName);

	// -(void)removeCmnPlist;
	[Export ("removeCmnPlist")]
	void RemoveCmnPlist ();

	// -(float)defaultCMNForAcousticModelAtPath:(NSString *)path;
	[Export ("defaultCMNForAcousticModelAtPath:")]
	float DefaultCMNForAcousticModelAtPath (string path);
}

// @interface OEContinuousModel : NSObject
[BaseType (typeof(NSObject))]
interface OEContinuousModel
{
	// -(void)listeningSessionWithLanguageModelAtPath:(NSString *)languageModelPath dictionaryAtPath:(NSString *)dictionaryPath acousticModelAtPath:(NSString *)acousticModelPath languageModelIsJSGF:(BOOL)languageModelIsJSGF;
	[Export ("listeningSessionWithLanguageModelAtPath:dictionaryAtPath:acousticModelAtPath:languageModelIsJSGF:")]
	void ListeningSessionWithLanguageModelAtPath (string languageModelPath, string dictionaryPath, string acousticModelPath, bool languageModelIsJSGF);

	// -(void)runRecognitionOnWavFileAtPath:(NSString *)wavPath usingLanguageModelAtPath:(NSString *)languageModelPath dictionaryAtPath:(NSString *)dictionaryPath acousticModelAtPath:(NSString *)acousticModelPath languageModelIsJSGF:(BOOL)languageModelIsJSGF;
	[Export ("runRecognitionOnWavFileAtPath:usingLanguageModelAtPath:dictionaryAtPath:acousticModelAtPath:languageModelIsJSGF:")]
	void RunRecognitionOnWavFileAtPath (string wavPath, string languageModelPath, string dictionaryPath, string acousticModelPath, bool languageModelIsJSGF);

	// -(void)resumeRecognition;
	[Export ("resumeRecognition")]
	void ResumeRecognition ();

	// -(void)suspendRecognition;
	[Export ("suspendRecognition")]
	void SuspendRecognition ();

	// -(void)changeLanguageModelToFile:(NSString *)languageModelPathAsString withDictionary:(NSString *)dictionaryPathAsString;
	[Export ("changeLanguageModelToFile:withDictionary:")]
	void ChangeLanguageModelToFile (string languageModelPathAsString, string dictionaryPathAsString);

	// -(void)removeCmnPlist;
	[Export ("removeCmnPlist")]
	void RemoveCmnPlist ();

	// -(void)testFileChange;
	[Export ("testFileChange")]
	void TestFileChange ();

	// -(NSError *)stopListening;
	[Export ("stopListening")]
	[Verify (MethodToProperty)]
	NSError StopListening { get; }

	// -(BOOL)dictionaryAtPathIsFromRuleORama:(NSString *)dictionaryPath;
	[Export ("dictionaryAtPathIsFromRuleORama:")]
	bool DictionaryAtPathIsFromRuleORama (string dictionaryPath);

	// -(BOOL)dictionaryAtPathIsFromRejecto:(NSString *)dictionaryPath;
	[Export ("dictionaryAtPathIsFromRejecto:")]
	bool DictionaryAtPathIsFromRejecto (string dictionaryPath);

	// -(BOOL)dictionaryAtPathIsFromRejectoOrRuleORama:(NSString *)dictionaryPath;
	[Export ("dictionaryAtPathIsFromRejectoOrRuleORama:")]
	bool DictionaryAtPathIsFromRejectoOrRuleORama (string dictionaryPath);

	// -(void)announceSetupFailureForReason:(NSString *)reasonForFailure;
	[Export ("announceSetupFailureForReason:")]
	void AnnounceSetupFailureForReason (string reasonForFailure);

	// -(BOOL)openEarsLoggingIsOn;
	[Export ("openEarsLoggingIsOn")]
	[Verify (MethodToProperty)]
	bool OpenEarsLoggingIsOn { get; }

	// -(BOOL)verbosePocketsphinxIsOn;
	[Export ("verbosePocketsphinxIsOn")]
	[Verify (MethodToProperty)]
	bool VerbosePocketsphinxIsOn { get; }

	// -(void)heartBeat;
	[Export ("heartBeat")]
	void HeartBeat ();

	// -(ps_decoder_t *)initializeDecoderForLanguageModelAtPath:(NSString *)languageModelPath dictionaryAtPath:(NSString *)dictionaryPath acousticModelAtPath:(NSString *)acousticModelPath languageModelIsJSGF:(BOOL)languageModelIsJSGF usingBestpath:(NSNumber *)usingBestpath;
	[Export ("initializeDecoderForLanguageModelAtPath:dictionaryAtPath:acousticModelAtPath:languageModelIsJSGF:usingBestpath:")]
	unsafe ps_decoder_t* InitializeDecoderForLanguageModelAtPath (string languageModelPath, string dictionaryPath, string acousticModelPath, bool languageModelIsJSGF, NSNumber usingBestpath);

	// -(void)setDecoder:(ps_decoder_t *)pocketSphinxDecoder toCmnValue:(float)previouscmn forAcousticModelAtPath:(NSString *)acousticModelPath;
	[Export ("setDecoder:toCmnValue:forAcousticModelAtPath:")]
	unsafe void SetDecoder (ps_decoder_t* pocketSphinxDecoder, float previouscmn, string acousticModelPath);

	// -(void)announceListening;
	[Export ("announceListening")]
	void AnnounceListening ();

	// -(void)announceLoopHasStartedWithDictionaryAtPath:(NSString *)dictionaryPath;
	[Export ("announceLoopHasStartedWithDictionaryAtPath:")]
	void AnnounceLoopHasStartedWithDictionaryAtPath (string dictionaryPath);

	// -(void)validateAndPerformLanguageModelChange;
	[Export ("validateAndPerformLanguageModelChange")]
	void ValidateAndPerformLanguageModelChange ();

	// -(void)performSingularStopForDecoder:(ps_decoder_t *)pocketSphinxDecoder;
	[Export ("performSingularStopForDecoder:")]
	unsafe void PerformSingularStopForDecoder (ps_decoder_t* pocketSphinxDecoder);

	// -(void)resetForNewUtteranceWithContextString:(NSString *)contextString;
	[Export ("resetForNewUtteranceWithContextString:")]
	void ResetForNewUtteranceWithContextString (string contextString);

	// -(void)announceSpeechDetection;
	[Export ("announceSpeechDetection")]
	void AnnounceSpeechDetection ();

	// -(void)announceSpeechCompleted;
	[Export ("announceSpeechCompleted")]
	void AnnounceSpeechCompleted ();

	// -(void)getAndReturnHypothesisForDecoder:(ps_decoder_t *)pocketSphinxDecoder;
	[Export ("getAndReturnHypothesisForDecoder:")]
	unsafe void GetAndReturnHypothesisForDecoder (ps_decoder_t* pocketSphinxDecoder);

	// -(NSInteger)startUtterance;
	[Export ("startUtterance")]
	[Verify (MethodToProperty)]
	nint StartUtterance { get; }

	// -(void)processRaw:(NSData *)buffer;
	[Export ("processRaw:")]
	void ProcessRaw (NSData buffer);

	// -(NSInteger)getInSpeech;
	[Export ("getInSpeech")]
	[Verify (MethodToProperty)]
	nint InSpeech { get; }

	// -(void)endUtterance;
	[Export ("endUtterance")]
	void EndUtterance ();

	// -(void)getNbestForDecoder:(ps_decoder_t *)pocketSphinxDecoder withHypothesis:(const char *)hypothesis andRecognitionScore:(int32)recognitionScore;
	[Export ("getNbestForDecoder:withHypothesis:andRecognitionScore:")]
	unsafe void GetNbestForDecoder (ps_decoder_t* pocketSphinxDecoder, sbyte* hypothesis, int recognitionScore);

	// -(const char *)getHypothesisFromDecoder:(ps_decoder_t *)pocketSphinxDecoder withScore:(SInt32 *)recognitionScore;
	[Export ("getHypothesisFromDecoder:withScore:")]
	unsafe sbyte* GetHypothesisFromDecoder (ps_decoder_t* pocketSphinxDecoder, int* recognitionScore);

	// -(SInt32)getProbabilityFromDecoder:(ps_decoder_t *)pocketSphinxDecoder;
	[Export ("getProbabilityFromDecoder:")]
	unsafe int GetProbabilityFromDecoder (ps_decoder_t* pocketSphinxDecoder);

	// -(ps_nbest_t *)nBest;
	[Export ("nBest")]
	[Verify (MethodToProperty)]
	unsafe ps_nbest_t* NBest { get; }

	// -(ps_nbest_t *)nBestNext:(ps_nbest_t *)nbest;
	[Export ("nBestNext:")]
	unsafe ps_nbest_t* NBestNext (ps_nbest_t* nbest);

	// -(const char *)nBestHypothesis:(ps_nbest_t *)nbest withScore:(int32 *)recognitionScore;
	[Export ("nBestHypothesis:withScore:")]
	unsafe sbyte* NBestHypothesis (ps_nbest_t* nbest, int* recognitionScore);

	// -(void)nBestFree:(ps_nbest_t *)nbest;
	[Export ("nBestFree:")]
	unsafe void NBestFree (ps_nbest_t* nbest);

	// -(const char *)searchHyp:(ps_decoder_t *)ps bestScore:(int *)out_best_score final:(int *)final;
	[Export ("searchHyp:bestScore:final:")]
	unsafe sbyte* SearchHyp (ps_decoder_t* ps, int* out_best_score, int* final);

	// @property (readonly, getter = getMeteringLevel, atomic) float meteringLevel;
	[Export ("meteringLevel")]
	float MeteringLevel { [Bind ("getMeteringLevel")] get; }

	// @property (assign, nonatomic) BOOL useSmartCMNWithTestFiles;
	[Export ("useSmartCMNWithTestFiles")]
	bool UseSmartCMNWithTestFiles { get; set; }

	// @property (assign, nonatomic) BOOL returnNbest;
	[Export ("returnNbest")]
	bool ReturnNbest { get; set; }

	// @property (assign, nonatomic) NSInteger nBestNumber;
	[Export ("nBestNumber")]
	nint NBestNumber { get; set; }

	// @property (assign, nonatomic) BOOL outputAudio;
	[Export ("outputAudio")]
	bool OutputAudio { get; set; }

	// @property (assign, nonatomic) BOOL isListening;
	[Export ("isListening")]
	bool IsListening { get; set; }

	// @property (assign, nonatomic) BOOL returnNullHypotheses;
	[Export ("returnNullHypotheses")]
	bool ReturnNullHypotheses { get; set; }

	// @property (assign, nonatomic) BOOL use8kMode;
	[Export ("use8kMode")]
	bool Use8kMode { get; set; }

	// @property (assign, nonatomic) float secondsOfSpeechToDetect;
	[Export ("secondsOfSpeechToDetect")]
	float SecondsOfSpeechToDetect { get; set; }

	// @property (assign, nonatomic) float secondsOfSilenceToDetect;
	[Export ("secondsOfSilenceToDetect")]
	float SecondsOfSilenceToDetect { get; set; }

	// @property (readonly, nonatomic) float lastCMNUsed;
	[Export ("lastCMNUsed")]
	float LastCMNUsed { get; }

	// @property (copy, nonatomic) NSString * pathToTestFile;
	[Export ("pathToTestFile")]
	string PathToTestFile { get; set; }

	// @property (copy, nonatomic) NSString * audioMode;
	[Export ("audioMode")]
	string AudioMode { get; set; }

	// @property (nonatomic, strong) OEContinuousAudioUnit * audioDriver;
	[Export ("audioDriver", ArgumentSemantic.Strong)]
	OEContinuousAudioUnit AudioDriver { get; set; }

	// @property (assign, nonatomic) NSInteger utteranceState;
	[Export ("utteranceState")]
	nint UtteranceState { get; set; }

	// @property (readonly, nonatomic) OESmartCMN * smartCMN;
	[Export ("smartCMN")]
	OESmartCMN SmartCMN { get; }

	// @property (assign, nonatomic) BOOL isSuspended;
	[Export ("isSuspended")]
	bool IsSuspended { get; set; }

	// @property (assign, nonatomic) BOOL safeToCallStart;
	[Export ("safeToCallStart")]
	bool SafeToCallStart { get; set; }

	// @property (assign, nonatomic) BOOL safeToCallStop;
	[Export ("safeToCallStop")]
	bool SafeToCallStop { get; set; }

	// @property (assign, nonatomic) ps_decoder_t * pocketSphinxDecoder;
	[Export ("pocketSphinxDecoder", ArgumentSemantic.Assign)]
	unsafe ps_decoder_t* PocketSphinxDecoder { get; set; }

	// @property (nonatomic, strong) NSMutableData * bufferAccumulator;
	[Export ("bufferAccumulator", ArgumentSemantic.Strong)]
	NSMutableData BufferAccumulator { get; set; }

	// @property (copy, nonatomic) NSString * languageModelFileToChangeTo;
	[Export ("languageModelFileToChangeTo")]
	string LanguageModelFileToChangeTo { get; set; }

	// @property (copy, nonatomic) NSString * dictionaryFileToChangeTo;
	[Export ("dictionaryFileToChangeTo")]
	string DictionaryFileToChangeTo { get; set; }

	// @property (copy, nonatomic) NSString * acousticModelPath;
	[Export ("acousticModelPath")]
	string AcousticModelPath { get; set; }

	// @property (nonatomic, strong) dispatch_source_t heartbeatTimer;
	[Export ("heartbeatTimer", ArgumentSemantic.Strong)]
	OS_dispatch_source HeartbeatTimer { get; set; }

	// @property (assign, nonatomic) BOOL shouldUseSmartCMN;
	[Export ("shouldUseSmartCMN")]
	bool ShouldUseSmartCMN { get; set; }

	// @property (assign, nonatomic) BOOL speechFramesFound;
	[Export ("speechFramesFound")]
	bool SpeechFramesFound { get; set; }

	// @property (assign, nonatomic) BOOL speechAlreadyInProgress;
	[Export ("speechAlreadyInProgress")]
	bool SpeechAlreadyInProgress { get; set; }

	// @property (assign, nonatomic) BOOL thereIsALanguageModelChangeRequest;
	[Export ("thereIsALanguageModelChangeRequest")]
	bool ThereIsALanguageModelChangeRequest { get; set; }

	// @property (assign, nonatomic) NSInteger utteranceID;
	[Export ("utteranceID")]
	nint UtteranceID { get; set; }

	// @property (assign, nonatomic) NSTimeInterval stuckUtterance;
	[Export ("stuckUtterance")]
	double StuckUtterance { get; set; }

	// @property (assign, nonatomic) BOOL legacy3rdPassMode;
	[Export ("legacy3rdPassMode")]
	bool Legacy3rdPassMode { get; set; }

	// @property (assign, nonatomic) BOOL requestToResume;
	[Export ("requestToResume")]
	bool RequestToResume { get; set; }

	// @property (assign, nonatomic) BOOL defaultSecondsOfSilenceInUse;
	[Export ("defaultSecondsOfSilenceInUse")]
	bool DefaultSecondsOfSilenceInUse { get; set; }

	// @property (assign, nonatomic) int frameRate;
	[Export ("frameRate")]
	int FrameRate { get; set; }

	// @property (assign, nonatomic) BOOL removingNoise;
	[Export ("removingNoise")]
	bool RemovingNoise { get; set; }

	// @property (assign, nonatomic) BOOL removingSilence;
	[Export ("removingSilence")]
	bool RemovingSilence { get; set; }

	// @property (assign, nonatomic) BOOL disableBluetooth;
	[Export ("disableBluetooth")]
	bool DisableBluetooth { get; set; }

	// @property (assign, nonatomic) BOOL disableMixing;
	[Export ("disableMixing")]
	bool DisableMixing { get; set; }

	// @property (assign, nonatomic) BOOL disablePreferredSampleRate;
	[Export ("disablePreferredSampleRate")]
	bool DisablePreferredSampleRate { get; set; }

	// @property (assign, nonatomic) BOOL disablePreferredBufferSize;
	[Export ("disablePreferredBufferSize")]
	bool DisablePreferredBufferSize { get; set; }

	// @property (assign, nonatomic) BOOL disablePreferredChannelNumber;
	[Export ("disablePreferredChannelNumber")]
	bool DisablePreferredChannelNumber { get; set; }

	// @property (assign, nonatomic) BOOL disableSessionResetsWhileStopped;
	[Export ("disableSessionResetsWhileStopped")]
	bool DisableSessionResetsWhileStopped { get; set; }

	// @property (assign, nonatomic) float vadThreshold;
	[Export ("vadThreshold")]
	float VadThreshold { get; set; }
}

// @interface OENotification : NSObject
[BaseType (typeof(NSObject))]
interface OENotification
{
	// +(void)performOpenEarsNotificationOnMainThread:(NSString *)notificationNameAsString withOptionalObjects:(NSArray *)objects andKeys:(NSArray *)keys;
	[Static]
	[Export ("performOpenEarsNotificationOnMainThread:withOptionalObjects:andKeys:")]
	[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
	void PerformOpenEarsNotificationOnMainThread (string notificationNameAsString, NSObject[] objects, NSObject[] keys);
}

// @interface OEPocketsphinxController : NSObject <OEEventsObserverDelegate>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface OEPocketsphinxController : IOEEventsObserverDelegate
{
	// -(void)startListeningWithLanguageModelAtPath:(NSString *)languageModelPath dictionaryAtPath:(NSString *)dictionaryPath acousticModelAtPath:(NSString *)acousticModelPath languageModelIsJSGF:(BOOL)languageModelIsJSGF;
	[Export ("startListeningWithLanguageModelAtPath:dictionaryAtPath:acousticModelAtPath:languageModelIsJSGF:")]
	void StartListeningWithLanguageModelAtPath (string languageModelPath, string dictionaryPath, string acousticModelPath, bool languageModelIsJSGF);

	// -(NSError *)stopListening;
	[Export ("stopListening")]
	[Verify (MethodToProperty)]
	NSError StopListening { get; }

	// -(void)suspendRecognition;
	[Export ("suspendRecognition")]
	void SuspendRecognition ();

	// -(void)resumeRecognition;
	[Export ("resumeRecognition")]
	void ResumeRecognition ();

	// -(void)changeLanguageModelToFile:(NSString *)languageModelPathAsString withDictionary:(NSString *)dictionaryPathAsString;
	[Export ("changeLanguageModelToFile:withDictionary:")]
	void ChangeLanguageModelToFile (string languageModelPathAsString, string dictionaryPathAsString);

	// @property (readonly, atomic) Float32 pocketsphinxInputLevel;
	[Export ("pocketsphinxInputLevel")]
	float PocketsphinxInputLevel { get; }

	// -(void)removeCmnPlist;
	[Export ("removeCmnPlist")]
	void RemoveCmnPlist ();

	// -(void)suspendRecognitionForFliteSpeech;
	[Export ("suspendRecognitionForFliteSpeech")]
	void SuspendRecognitionForFliteSpeech ();

	// -(void)resumeRecognitionForFliteSpeech;
	[Export ("resumeRecognitionForFliteSpeech")]
	void ResumeRecognitionForFliteSpeech ();

	// -(void)setSecondsOfSilence;
	[Export ("setSecondsOfSilence")]
	void SetSecondsOfSilence ();

	// -(void)validateNBestSettings;
	[Export ("validateNBestSettings")]
	void ValidateNBestSettings ();

	// -(void)runRecognitionOnWavFileAtPath:(NSString *)wavPath usingLanguageModelAtPath:(NSString *)languageModelPath dictionaryAtPath:(NSString *)dictionaryPath acousticModelAtPath:(NSString *)acousticModelPath languageModelIsJSGF:(BOOL)languageModelIsJSGF;
	[Export ("runRecognitionOnWavFileAtPath:usingLanguageModelAtPath:dictionaryAtPath:acousticModelAtPath:languageModelIsJSGF:")]
	void RunRecognitionOnWavFileAtPath (string wavPath, string languageModelPath, string dictionaryPath, string acousticModelPath, bool languageModelIsJSGF);

	// -(void)requestMicPermission;
	[Export ("requestMicPermission")]
	void RequestMicPermission ();

	// @property (readonly, atomic) BOOL micPermissionIsGranted;
	[Export ("micPermissionIsGranted")]
	bool MicPermissionIsGranted { get; }

	// +(OEPocketsphinxController *)sharedInstance;
	[Static]
	[Export ("sharedInstance")]
	[Verify (MethodToProperty)]
	OEPocketsphinxController SharedInstance { get; }

	// -(BOOL)setActive:(BOOL)active error:(NSError **)outError;
	[Export ("setActive:error:")]
	bool SetActive (bool active, out NSError outError);

	// @property (nonatomic, strong) OEContinuousModel * continuousModel;
	[Export ("continuousModel", ArgumentSemantic.Strong)]
	OEContinuousModel ContinuousModel { get; set; }

	// @property (nonatomic, strong) NSOperationQueue * pocketsphinxControllerQueue;
	[Export ("pocketsphinxControllerQueue", ArgumentSemantic.Strong)]
	NSOperationQueue PocketsphinxControllerQueue { get; set; }

	// @property (nonatomic, strong) OEEventsObserver * openEarsEventsObserver;
	[Export ("openEarsEventsObserver", ArgumentSemantic.Strong)]
	OEEventsObserver OpenEarsEventsObserver { get; set; }

	// @property (assign, nonatomic) float secondsOfSilenceToDetect;
	[Export ("secondsOfSilenceToDetect")]
	float SecondsOfSilenceToDetect { get; set; }

	// @property (assign, nonatomic) BOOL returnNbest;
	[Export ("returnNbest")]
	bool ReturnNbest { get; set; }

	// @property (assign, nonatomic) int nBestNumber;
	[Export ("nBestNumber")]
	int NBestNumber { get; set; }

	// @property (assign, nonatomic) BOOL verbosePocketSphinx;
	[Export ("verbosePocketSphinx")]
	bool VerbosePocketSphinx { get; set; }

	// @property (assign, nonatomic) BOOL returnNullHypotheses;
	[Export ("returnNullHypotheses")]
	bool ReturnNullHypotheses { get; set; }

	// @property (assign, nonatomic) BOOL use8kMode;
	[Export ("use8kMode")]
	bool Use8kMode { get; set; }

	// @property (assign, nonatomic) BOOL isSuspended;
	[Export ("isSuspended")]
	bool IsSuspended { get; set; }

	// @property (assign, nonatomic) BOOL isListening;
	[Export ("isListening")]
	bool IsListening { get; set; }

	// @property (assign, nonatomic) BOOL legacy3rdPassMode;
	[Export ("legacy3rdPassMode")]
	bool Legacy3rdPassMode { get; set; }

	// @property (assign, nonatomic) BOOL removingNoise;
	[Export ("removingNoise")]
	bool RemovingNoise { get; set; }

	// @property (assign, nonatomic) BOOL removingSilence;
	[Export ("removingSilence")]
	bool RemovingSilence { get; set; }

	// @property (assign, nonatomic) float vadThreshold;
	[Export ("vadThreshold")]
	float VadThreshold { get; set; }

	// @property (assign, nonatomic) BOOL disableBluetooth;
	[Export ("disableBluetooth")]
	bool DisableBluetooth { get; set; }

	// @property (assign, nonatomic) BOOL disableMixing;
	[Export ("disableMixing")]
	bool DisableMixing { get; set; }

	// @property (assign, nonatomic) BOOL disableSessionResetsWhileStopped;
	[Export ("disableSessionResetsWhileStopped")]
	bool DisableSessionResetsWhileStopped { get; set; }

	// @property (assign, nonatomic) BOOL disablePreferredSampleRate;
	[Export ("disablePreferredSampleRate")]
	bool DisablePreferredSampleRate { get; set; }

	// @property (assign, nonatomic) BOOL disablePreferredBufferSize;
	[Export ("disablePreferredBufferSize")]
	bool DisablePreferredBufferSize { get; set; }

	// @property (assign, nonatomic) BOOL disablePreferredChannelNumber;
	[Export ("disablePreferredChannelNumber")]
	bool DisablePreferredChannelNumber { get; set; }

	// @property (copy, nonatomic) NSString * audioMode;
	[Export ("audioMode")]
	string AudioMode { get; set; }

	// @property (copy, nonatomic) NSString * pathToTestFile;
	[Export ("pathToTestFile")]
	string PathToTestFile { get; set; }

	// @property (assign, nonatomic) BOOL useSmartCMNWithTestFiles;
	[Export ("useSmartCMNWithTestFiles")]
	bool UseSmartCMNWithTestFiles { get; set; }

	// @property (assign, nonatomic) BOOL defaultSecondsOfSilenceInUse;
	[Export ("defaultSecondsOfSilenceInUse")]
	bool DefaultSecondsOfSilenceInUse { get; set; }

	// @property (assign, nonatomic) BOOL outputAudio;
	[Export ("outputAudio")]
	bool OutputAudio { get; set; }

	// @property (assign, nonatomic) BOOL micPermission;
	[Export ("micPermission")]
	bool MicPermission { get; set; }

	// @property (assign, nonatomic) BOOL doNotWarnAboutPermissions;
	[Export ("doNotWarnAboutPermissions")]
	bool DoNotWarnAboutPermissions { get; set; }

	// @property (assign, nonatomic) BOOL starting;
	[Export ("starting")]
	bool Starting { get; set; }
}
