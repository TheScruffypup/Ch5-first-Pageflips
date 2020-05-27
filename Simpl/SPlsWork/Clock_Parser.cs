using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_CLOCK_PARSER
{
    public class UserModuleClass_CLOCK_PARSER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput UPDATE_TIME;
        Crestron.Logos.SplusObjects.AnalogInput TIME_FORMAT;
        Crestron.Logos.SplusObjects.StringInput TOD__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TIME__DOLLAR__;
        ushort SECONDSPASTMINUTE = 0;
        ushort WAITTIME = 0;
        ushort ANA_HOUR = 0;
        ushort ANA_MINUTE = 0;
        ushort HOUR12 = 0;
        CrestronString HOUR;
        CrestronString COLLON;
        CrestronString MINUTE;
        CrestronString AM_PM;
        CrestronString HOUR2;
        CrestronString TWELVEHOUR;
        object UPDATE_TIME_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 172;
                ANA_HOUR = (ushort) ( Functions.GetHourNum() ) ; 
                __context__.SourceCodeLine = 173;
                ANA_MINUTE = (ushort) ( Functions.GetMinutesNum() ) ; 
                __context__.SourceCodeLine = 176;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ANA_HOUR == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 178;
                    TWELVEHOUR  .UpdateValue ( "12"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 181;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ANA_HOUR < 12 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 183;
                    AM_PM  .UpdateValue ( "am"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 185;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ANA_HOUR > 11 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 187;
                    AM_PM  .UpdateValue ( "pm"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 189;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ANA_HOUR > 12 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 192;
                    TWELVEHOUR  .UpdateValue ( Functions.ItoA (  (int) ( (ANA_HOUR - 12) ) )  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 196;
                    TWELVEHOUR  .UpdateValue ( Functions.ItoA (  (int) ( ANA_HOUR ) )  ) ; 
                    } 
                
                __context__.SourceCodeLine = 200;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ANA_MINUTE < 10 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 202;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TIME_FORMAT  .UshortValue == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 205;
                        MakeString ( TIME__DOLLAR__ , "{0}:0{1} {2}", TWELVEHOUR , Functions.ItoA (  (int) ( ANA_MINUTE ) ) , AM_PM ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 207;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TIME_FORMAT  .UshortValue == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 210;
                        MakeString ( TIME__DOLLAR__ , "{0}:0{1}", HOUR , MINUTE ) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 215;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TIME_FORMAT  .UshortValue == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 218;
                        MakeString ( TIME__DOLLAR__ , "{0}:{1} {2}", TWELVEHOUR , Functions.ItoA (  (int) ( ANA_MINUTE ) ) , AM_PM ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 220;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TIME_FORMAT  .UshortValue == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 223;
                        MakeString ( TIME__DOLLAR__ , "{0}:{1}", HOUR , MINUTE ) ; 
                        } 
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 243;
            SECONDSPASTMINUTE = (ushort) ( Functions.GetSecondsNum() ) ; 
            __context__.SourceCodeLine = 244;
            WAITTIME = (ushort) ( (((60 - SECONDSPASTMINUTE) + 1) * 100) ) ; 
            __context__.SourceCodeLine = 245;
            while ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 247;
                Functions.Delay (  (int) ( WAITTIME ) ) ; 
                __context__.SourceCodeLine = 250;
                HOUR  .UpdateValue ( Functions.Mid ( TOD__DOLLAR__ ,  (int) ( 9 ) ,  (int) ( 2 ) )  ) ; 
                __context__.SourceCodeLine = 251;
                MINUTE  .UpdateValue ( Functions.Mid ( TOD__DOLLAR__ ,  (int) ( 11 ) ,  (int) ( 2 ) )  ) ; 
                __context__.SourceCodeLine = 252;
                HOUR2  .UpdateValue ( Functions.ItoA (  (int) ( ANA_HOUR ) )  ) ; 
                __context__.SourceCodeLine = 253;
                ANA_HOUR = (ushort) ( Functions.Atoi( HOUR ) ) ; 
                __context__.SourceCodeLine = 255;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ANA_HOUR == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 257;
                    TWELVEHOUR  .UpdateValue ( "12"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 260;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ANA_HOUR < 12 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 262;
                    AM_PM  .UpdateValue ( "am"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 264;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ANA_HOUR > 11 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 266;
                    AM_PM  .UpdateValue ( "pm"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 268;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ANA_HOUR > 12 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 271;
                    TWELVEHOUR  .UpdateValue ( Functions.ItoA (  (int) ( (ANA_HOUR - 12) ) )  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 275;
                    TWELVEHOUR  .UpdateValue ( Functions.ItoA (  (int) ( ANA_HOUR ) )  ) ; 
                    } 
                
                __context__.SourceCodeLine = 279;
                TIME__DOLLAR__  .UpdateValue ( TWELVEHOUR + ":" + MINUTE + " " + AM_PM  ) ; 
                __context__.SourceCodeLine = 281;
                SECONDSPASTMINUTE = (ushort) ( Functions.GetSecondsNum() ) ; 
                __context__.SourceCodeLine = 282;
                WAITTIME = (ushort) ( (((60 - SECONDSPASTMINUTE) + 1) * 100) ) ; 
                __context__.SourceCodeLine = 245;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        HOUR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
        COLLON  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
        MINUTE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
        AM_PM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
        HOUR2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
        TWELVEHOUR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
        
        UPDATE_TIME = new Crestron.Logos.SplusObjects.DigitalInput( UPDATE_TIME__DigitalInput__, this );
        m_DigitalInputList.Add( UPDATE_TIME__DigitalInput__, UPDATE_TIME );
        
        TIME_FORMAT = new Crestron.Logos.SplusObjects.AnalogInput( TIME_FORMAT__AnalogSerialInput__, this );
        m_AnalogInputList.Add( TIME_FORMAT__AnalogSerialInput__, TIME_FORMAT );
        
        TOD__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( TOD__DOLLAR____AnalogSerialInput__, 100, this );
        m_StringInputList.Add( TOD__DOLLAR____AnalogSerialInput__, TOD__DOLLAR__ );
        
        TIME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TIME__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( TIME__DOLLAR____AnalogSerialOutput__, TIME__DOLLAR__ );
        
        
        UPDATE_TIME.OnDigitalPush.Add( new InputChangeHandlerWrapper( UPDATE_TIME_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_CLOCK_PARSER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint UPDATE_TIME__DigitalInput__ = 0;
    const uint TIME_FORMAT__AnalogSerialInput__ = 0;
    const uint TOD__DOLLAR____AnalogSerialInput__ = 1;
    const uint TIME__DOLLAR____AnalogSerialOutput__ = 0;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
