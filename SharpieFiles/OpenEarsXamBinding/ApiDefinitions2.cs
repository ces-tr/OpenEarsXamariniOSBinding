using Foundation;
using ObjCRuntime;
using OpenEars;

// @interface OEGrammarGenerator : NSObject
[BaseType (typeof(NSObject))]
interface OEGrammarGenerator
{
	[Wrap ("WeakDelegate")]
	OEGrammarGeneratorDelegate Delegate { get; set; }

	// @property (weak) id<OEGrammarGeneratorDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (copy, nonatomic) NSString * acousticModelPath;
	[Export ("acousticModelPath")]
	string AcousticModelPath { get; set; }

	// @property (copy, nonatomic) NSString * plistPath;
	[Export ("plistPath")]
	string PlistPath { get; set; }

	// -(NSMutableString *)deriveRuleString:(NSString *)workingString withRuleType:(NSString *)ruleType addingWordsToMutableArray:(NSMutableArray *)phoneticDictionaryArray;
	[Export ("deriveRuleString:withRuleType:addingWordsToMutableArray:")]
	NSMutableString DeriveRuleString (string workingString, string ruleType, NSMutableArray phoneticDictionaryArray);

	// -(void)addWorkingString:(NSString *)workingString toRuleArray:(NSMutableArray *)arrayToAdd withRuleType:(NSString *)ruleType isPublic:(BOOL)isPublic;
	[Export ("addWorkingString:toRuleArray:withRuleType:isPublic:")]
	void AddWorkingString (string workingString, NSMutableArray arrayToAdd, string ruleType, bool isPublic);

	// -(NSError *)createGrammarFromDictionary:(NSDictionary *)grammarDictionary withRequestedName:(NSString *)fileName creatingPhoneticDictionaryArray:(NSArray *)phoneticDictionaryArray;
	[Export ("createGrammarFromDictionary:withRequestedName:creatingPhoneticDictionaryArray:")]
	[Verify (StronglyTypedNSArray)]
	NSError CreateGrammarFromDictionary (NSDictionary grammarDictionary, string fileName, NSObject[] phoneticDictionaryArray);

	// -(NSString *)analyzeRuleString:(NSString *)ruleString;
	[Export ("analyzeRuleString:")]
	string AnalyzeRuleString (string ruleString);

	// -(NSError *)outputJSGFFromRuleArray:(NSArray *)ruleArray usingRuleNumberArray:(NSArray *)ruleNumberArray withRequestedName:(NSString *)fileName;
	[Export ("outputJSGFFromRuleArray:usingRuleNumberArray:withRequestedName:")]
	[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
	NSError OutputJSGFFromRuleArray (NSObject[] ruleArray, NSObject[] ruleNumberArray, string fileName);

	// -(void)processMutableString:(NSMutableString *)mutableString fromRuleArray:(NSArray *)ruleArray atIndex:(int)arrayIndex withSeparator:(NSString *)separator bracket:(BOOL)bracket endCharacter:(NSString *)endCharacter;
	[Export ("processMutableString:fromRuleArray:atIndex:withSeparator:bracket:endCharacter:")]
	[Verify (StronglyTypedNSArray)]
	void ProcessMutableString (NSMutableString mutableString, NSObject[] ruleArray, int arrayIndex, string separator, bool bracket, string endCharacter);

	// -(NSError *)prepareGrammarForGenerationUsingDictionary:(NSDictionary *)grammarDictionary withRequestedName:(NSString *)fileName creatingPhoneticDictionaryArray:(NSMutableArray *)phoneticDictionaryArray withRuleArray:(NSMutableArray *)ruleArray andRuleNumberArray:(NSMutableArray *)ruleNumberArray;
	[Export ("prepareGrammarForGenerationUsingDictionary:withRequestedName:creatingPhoneticDictionaryArray:withRuleArray:andRuleNumberArray:")]
	NSError PrepareGrammarForGenerationUsingDictionary (NSDictionary grammarDictionary, string fileName, NSMutableArray phoneticDictionaryArray, NSMutableArray ruleArray, NSMutableArray ruleNumberArray);

	// -(void)cleanUpAfterGeneration;
	[Export ("cleanUpAfterGeneration")]
	void CleanUpAfterGeneration ();
}

// @protocol OEGrammarGeneratorDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface OEGrammarGeneratorDelegate
{
	// @optional -(NSArray *)compactWhitespaceAndFixCharactersOfArrayEntries:(NSArray *)array;
	[Export ("compactWhitespaceAndFixCharactersOfArrayEntries:")]
	[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
	NSObject[] CompactWhitespaceAndFixCharactersOfArrayEntries (NSObject[] array);

	// @optional -(NSError *)checkModelForContent:(NSArray *)normalizedLanguageModelArray;
	[Export ("checkModelForContent:")]
	[Verify (StronglyTypedNSArray)]
	NSError CheckModelForContent (NSObject[] normalizedLanguageModelArray);

	// @optional -(void)checkCaseOfWords:(NSArray *)languageModelArray forAcousticModelAtPath:(NSString *)acousticModelPath;
	[Export ("checkCaseOfWords:forAcousticModelAtPath:")]
	[Verify (StronglyTypedNSArray)]
	void CheckCaseOfWords (NSObject[] languageModelArray, string acousticModelPath);

	// @optional -(NSError *)createDictionaryFromWordArray:(NSArray *)normalizedLanguageModelArray intoDictionaryArray:(NSArray *)dictionaryResultsArray usingAcousticModelAtPath:(NSString *)acousticModelPath;
	[Export ("createDictionaryFromWordArray:intoDictionaryArray:usingAcousticModelAtPath:")]
	[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
	NSError CreateDictionaryFromWordArray (NSObject[] normalizedLanguageModelArray, NSObject[] dictionaryResultsArray, string acousticModelPath);
}

// @interface OELanguageModelGenerator : NSObject <OEGrammarGeneratorDelegate>
[BaseType (typeof(NSObject))]
interface OELanguageModelGenerator : IOEGrammarGeneratorDelegate
{
	// @property (assign, nonatomic) BOOL verboseLanguageModelGenerator;
	[Export ("verboseLanguageModelGenerator")]
	bool VerboseLanguageModelGenerator { get; set; }

	// @property (copy, nonatomic) NSString * pathToCachesDirectory;
	[Export ("pathToCachesDirectory")]
	string PathToCachesDirectory { get; set; }

	// @property (nonatomic, strong) OEGraphemeGenerator * graphemeGenerator;
	[Export ("graphemeGenerator", ArgumentSemantic.Strong)]
	OEGraphemeGenerator GraphemeGenerator { get; set; }

	// @property (nonatomic, strong) NSNumber * ngrams;
	[Export ("ngrams", ArgumentSemantic.Strong)]
	NSNumber Ngrams { get; set; }

	// @property (nonatomic, strong) NSMutableArray * iterationStorageArray;
	[Export ("iterationStorageArray", ArgumentSemantic.Strong)]
	NSMutableArray IterationStorageArray { get; set; }

	// -(NSError *)writeOutCorpusForArray:(NSArray *)normalizedLanguageModelArray toFilename:(NSString *)fileName;
	[Export ("writeOutCorpusForArray:toFilename:")]
	[Verify (StronglyTypedNSArray)]
	NSError WriteOutCorpusForArray (NSObject[] normalizedLanguageModelArray, string fileName);

	// -(void)createLanguageModelFromFilename:(NSString *)fileName;
	[Export ("createLanguageModelFromFilename:")]
	void CreateLanguageModelFromFilename (string fileName);

	// -(NSError *)generateLanguageModelFromArray:(NSArray *)languageModelArray withFilesNamed:(NSString *)fileName forAcousticModelAtPath:(NSString *)acousticModelPath;
	[Export ("generateLanguageModelFromArray:withFilesNamed:forAcousticModelAtPath:")]
	[Verify (StronglyTypedNSArray)]
	NSError GenerateLanguageModelFromArray (NSObject[] languageModelArray, string fileName, string acousticModelPath);

	// -(NSString *)pathToSuccessfullyGeneratedDictionaryWithRequestedName:(NSString *)name;
	[Export ("pathToSuccessfullyGeneratedDictionaryWithRequestedName:")]
	string PathToSuccessfullyGeneratedDictionaryWithRequestedName (string name);

	// -(NSString *)pathToSuccessfullyGeneratedLanguageModelWithRequestedName:(NSString *)name;
	[Export ("pathToSuccessfullyGeneratedLanguageModelWithRequestedName:")]
	string PathToSuccessfullyGeneratedLanguageModelWithRequestedName (string name);

	// -(NSString *)pathToSuccessfullyGeneratedGrammarWithRequestedName:(NSString *)name;
	[Export ("pathToSuccessfullyGeneratedGrammarWithRequestedName:")]
	string PathToSuccessfullyGeneratedGrammarWithRequestedName (string name);

	// -(NSError *)generateGrammarFromDictionary:(NSDictionary *)grammarDictionary withFilesNamed:(NSString *)fileName forAcousticModelAtPath:(NSString *)acousticModelPath;
	[Export ("generateGrammarFromDictionary:withFilesNamed:forAcousticModelAtPath:")]
	NSError GenerateGrammarFromDictionary (NSDictionary grammarDictionary, string fileName, string acousticModelPath);

	// -(NSError *)generateLanguageModelFromTextFile:(NSString *)pathToTextFile withFilesNamed:(NSString *)fileName forAcousticModelAtPath:(NSString *)acousticModelPath;
	[Export ("generateLanguageModelFromTextFile:withFilesNamed:forAcousticModelAtPath:")]
	NSError GenerateLanguageModelFromTextFile (string pathToTextFile, string fileName, string acousticModelPath);
}
