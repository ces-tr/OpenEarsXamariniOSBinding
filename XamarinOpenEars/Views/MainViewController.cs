using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using OpenEarsXamBinding;
using UIKit;

namespace XamarinOpenEars.Views {

    public partial class MainViewController : UIViewController {

        private OEEventsObserver openEarsEventsObserver;
        private string pathToFirstDynamicallyGeneratedLanguageModel;
        private string pathToFirstDynamicallyGeneratedDictionary;
        private OEPocketsphinxController pocketSphinxInstance;

        //Speech Service
        private string lastcommand;

        Dictionary<string, Func<Action<object>>> CommandMapping;

        public MainViewController() : base("MainViewController", null)
        {
            CommandMapping = new Dictionary<string, Func<Action<object>>>()
            {
                {"backward",() => Backward},
                {"change", () => Change},
                {"forward", () => Forward},
                {"turn", () => Turn},
            };
        }

        private void Turn(object obj)
        {
            txtCommand.Text = $"Turn";
        }

        private void Forward(object obj)
        {
            txtCommand.Text = $"Forward";
        }

        private void Change(object obj)
        {
            txtCommand.Text = $"Change";
        }

        private void Backward(object obj)
        {
            txtCommand.Text = $"Backward";
        }



        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NSError error;

            OEEventsObserverDelegateProperties eEventsObserverDelegateProperties = new OEEventsObserverDelegateProperties();

            this.openEarsEventsObserver = new OEEventsObserver();//[[OEEventsObserver alloc] init];

            OEEventsObserverDelegateImplementation oEEventsObserverDelegateImplementation = new OEEventsObserverDelegateImplementation();
            oEEventsObserverDelegateImplementation.OnPocketsphinxDidReceiveHypothesis += OnHypothesisResult;
            this.openEarsEventsObserver.Delegate = oEEventsObserverDelegateImplementation;

            pocketSphinxInstance = OEPocketsphinxController.SharedInstance;
            pocketSphinxInstance.VerbosePocketSphinx = true;
            pocketSphinxInstance.SetActive(true, out error);

            string[] initialCommands = {    @"backward", // There is no case requirement in OpenEars,
                                            @"change", // so these can be uppercase, lowercase, or mixed case.
                                            @"forward",
                                            @"go",
                                            @"left",
                                            @"model",
                                            @"right",
                                            @"turn"

                                            };
            NSArray firstLanguageArray = NSArray.FromObjects(initialCommands);


            OELanguageModelGenerator languageModelGenerator = new OELanguageModelGenerator();//[[OELanguageModelGenerator alloc] init];

            languageModelGenerator.GenerateLanguageModelFromArray(firstLanguageArray, "FirstOpenEarsDynamicLanguageModel", "AcousticModelEnglish.bundle");
            /*
            NSError *error = [languageModelGenerator generateLanguageModelFromArray:firstLanguageArray withFilesNamed:@"FirstOpenEarsDynamicLanguageModel" forAcousticModelAtPath:[OEAcousticModel pathToModel:@"AcousticModelEnglish"]];
            */

            if(error != null) {

                Console.WriteLine($"Dynamic language generator reported error  {error.Description}");

            }
            else {

                this.pathToFirstDynamicallyGeneratedLanguageModel = languageModelGenerator.PathToSuccessfullyGeneratedLanguageModelWithRequestedName(@"FirstOpenEarsDynamicLanguageModel");
                this.pathToFirstDynamicallyGeneratedDictionary = languageModelGenerator.PathToSuccessfullyGeneratedDictionaryWithRequestedName(@"FirstOpenEarsDynamicLanguageModel");
                // Next, an informative message.
                pocketSphinxInstance.SetActive(true,  out error);

                if (!pocketSphinxInstance.IsListening) {

                    pocketSphinxInstance.StartListeningWithLanguageModelAtPath(pathToFirstDynamicallyGeneratedLanguageModel, pathToFirstDynamicallyGeneratedDictionary, OEAcousticModel.PathToModel(@"AcousticModelEnglish"),false);
                }


            }

            eEventsObserverDelegateProperties.usingStartingLanguageModel = true;

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            AddEventHandlers();
        }

        public override void ViewWillDisappear(bool animated)
        {
            RemoveEventHandlers();
            base.ViewWillDisappear(animated);
        }

        private void AddEventHandlers()
        {
            btnStart.TouchUpInside += BtnStart_TouchUpInside;
        }

        private void RemoveEventHandlers()
        {
            btnStart.TouchUpInside -= BtnStart_TouchUpInside;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void OnHypothesisResult(string hypothesis)
        {
            string chorizo = hypothesis.Trim();

            int backwardCommand = chorizo.LastIndexOf("backward", StringComparison.InvariantCultureIgnoreCase);
            int changeCommand = chorizo.LastIndexOf("change", StringComparison.InvariantCultureIgnoreCase);
            int forwardCommand = chorizo.LastIndexOf("forward", StringComparison.InvariantCultureIgnoreCase);
            int turnCommand = chorizo.LastIndexOf("turn", StringComparison.InvariantCultureIgnoreCase);


            try {
                int[] arr = new int[] { backwardCommand,
                                    changeCommand ,
                                    forwardCommand,
                                    turnCommand };

                int maxval = arr.Max();

                int it = Array.IndexOf(arr, maxval);

                SpeechCommands Command = (SpeechCommands)it;

                string commandstr = chorizo.Substring(maxval, chorizo.Length - maxval);

                System.Console.WriteLine("max" + maxval);

                System.Console.WriteLine(Command);

                string[] arraySplitted = commandstr.Split(" ");

                pocketSphinxInstance.StopListening();

                lastcommand = commandstr;

                if (CommandMapping.Keys.Contains(arraySplitted[0])) {

                    Func<Action<object>> execfunc;
                    Action<object> fun;

                    execfunc = CommandMapping.FirstOrDefault(x => x.Key.Equals(arraySplitted[0])).Value;
                    fun = execfunc?.Invoke();
                    fun?.Invoke(null);
                }

            }
            catch (Exception e) {

                Console.WriteLine("Could not parse any command");
                Console.WriteLine(e.StackTrace);

            }

            if (!pocketSphinxInstance.IsListening) {
                pocketSphinxInstance.StartListeningWithLanguageModelAtPath(pathToFirstDynamicallyGeneratedLanguageModel, pathToFirstDynamicallyGeneratedDictionary, OEAcousticModel.PathToModel(@"AcousticModelEnglish"), false);

            }

        }


        void BtnStart_TouchUpInside(object sender, EventArgs e)
        {
           if (!pocketSphinxInstance.IsListening)
            {
                pocketSphinxInstance.StartListeningWithLanguageModelAtPath(pathToFirstDynamicallyGeneratedLanguageModel, pathToFirstDynamicallyGeneratedDictionary, OEAcousticModel.PathToModel(@"AcousticModelEnglish"), false);

            }
        }

    }

    public class OEEventsObserverDelegateImplementation : OEEventsObserverDelegate 
    {
       public event Action<string> OnPocketsphinxDidReceiveHypothesis;

        public OEEventsObserverDelegateImplementation() 
        {
            //this.oEEventsObserverDelegateProperties = oEEventsObserverDelegateProperties;
        }

        public override void PocketsphinxDidReceiveHypothesis(string hypothesis, string recognitionScore, string utteranceID)
        {
            Console.WriteLine($"Local callback: The received hypothesis is {hypothesis} with a score of {recognitionScore} and an ID of {utteranceID}"); // Log it.
            OnPocketsphinxDidReceiveHypothesis?.Invoke(hypothesis);

        }

        public override void PocketsphinxDidReceiveNBestHypothesisArray(NSArray hypothesisArray)
        {

            Console.WriteLine($"Local callback: The received NBest hypothesis is {hypothesisArray}");
        }

        public override void PocketsphinxDidStartListening()
        {
            Console.WriteLine(@"Local callback: Pocketsphinx is now listening.");
        }

        public override void PocketsphinxDidDetectSpeech()
        {
            Console.WriteLine(@"Local callback: Pocketsphinx detected speech.");
        }

    }

    public enum SpeechCommands {
        Backward,
        Change,
        Forward,
        Turn

    }

    public class OEEventsObserverDelegateProperties {

        public bool usingStartingLanguageModel;
    }
}

