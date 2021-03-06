﻿#pragma checksum "C:\Users\Jussi\Source\Repos\Olio-Harj\CrimsonClone\CrimsonClone\Pages\GamePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "04B6A4E74E4A69312B7B5CC25FF3886F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrimsonClone
{
    partial class GamePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        private class GamePage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IGamePage_Bindings
        {
            private global::CrimsonClone.GamePage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj4;
            private global::Windows.UI.Xaml.Controls.TextBlock obj6;

            private GamePage_obj1_BindingsTracking bindingsTracking;

            public GamePage_obj1_Bindings()
            {
                this.bindingsTracking = new GamePage_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 6:
                        this.obj6 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            // IGamePage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // GamePage_obj1_Bindings

            public void SetDataRoot(global::CrimsonClone.GamePage newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::CrimsonClone.GamePage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_game(obj.game, phase);
                    }
                }
            }
            private void Update_game(global::CrimsonClone.Classes.Game obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_game(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_game_Score(obj.Score, phase);
                        this.Update_game_TickCount(obj.TickCount, phase);
                    }
                }
            }
            private void Update_game_Score(global::System.Int32 obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj4, obj.ToString(), null);
                }
            }
            private void Update_game_TickCount(global::System.Int32 obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj6, obj.ToString(), null);
                }
            }

            private class GamePage_obj1_BindingsTracking
            {
                global::System.WeakReference<GamePage_obj1_Bindings> WeakRefToBindingObj; 

                public GamePage_obj1_BindingsTracking(GamePage_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<GamePage_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_game(null);
                }

                public void PropertyChanged_game(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    GamePage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::CrimsonClone.Classes.Game obj = sender as global::CrimsonClone.Classes.Game;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_game_Score(obj.Score, DATA_CHANGED);
                                    bindings.Update_game_TickCount(obj.TickCount, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "Score":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_game_Score(obj.Score, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "TickCount":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_game_TickCount(obj.TickCount, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::CrimsonClone.Classes.Game cache_game = null;
                public void UpdateChildListeners_game(global::CrimsonClone.Classes.Game obj)
                {
                    if (obj != cache_game)
                    {
                        if (cache_game != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_game).PropertyChanged -= PropertyChanged_game;
                            cache_game = null;
                        }
                        if (obj != null)
                        {
                            cache_game = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_game;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2:
                {
                    this.GameCanvas = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                    #line 21 "..\..\..\Pages\GamePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Canvas)this.GameCanvas).PointerMoved += this.MyCanvas_PointerMoved;
                    #line 22 "..\..\..\Pages\GamePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Canvas)this.GameCanvas).PointerPressed += this.GameCanvas_PointerPressed;
                    #line 23 "..\..\..\Pages\GamePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Canvas)this.GameCanvas).PointerReleased += this.GameCanvas_PointerReleased;
                    #line default
                }
                break;
            case 3:
                {
                    this.textScore = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.scoreTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.textTime = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.timeTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    GamePage_obj1_Bindings bindings = new GamePage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

