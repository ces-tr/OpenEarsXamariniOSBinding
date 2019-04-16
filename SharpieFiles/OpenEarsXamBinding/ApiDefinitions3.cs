using Foundation;
using ObjCRuntime;

// @interface OEGraphemeGenerator : NSObject
[BaseType (typeof(NSObject))]
interface OEGraphemeGenerator
{
	// -(NSString *)getPhonemesForWordUsingGeneralizedG2P:(NSString *)word usingG2PDictionary:(NSDictionary *)lookupDictionary forAcousticModelNamed:(NSString *)acousticModelName usingUnigramsOnly:(BOOL)unigramsOnly verbose:(BOOL)verbose;
	[Export ("getPhonemesForWordUsingGeneralizedG2P:usingG2PDictionary:forAcousticModelNamed:usingUnigramsOnly:verbose:")]
	string GetPhonemesForWordUsingGeneralizedG2P (string word, NSDictionary lookupDictionary, string acousticModelName, bool unigramsOnly, bool verbose);

	// @property (strong) NSCharacterSet * charactersToRemove;
	[Export ("charactersToRemove", ArgumentSemantic.Strong)]
	NSCharacterSet CharactersToRemove { get; set; }
}
