using Foundation;

// @interface OEAcousticModel : NSObject
[BaseType (typeof(NSObject))]
interface OEAcousticModel
{
	// +(NSString *)pathToModel:(NSString *)acousticModelBundleName;
	[Static]
	[Export ("pathToModel:")]
	string PathToModel (string acousticModelBundleName);
}
