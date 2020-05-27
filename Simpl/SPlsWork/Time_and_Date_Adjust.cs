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

namespace UserModule_TIME_AND_DATE_ADJUST
{
    public class UserModuleClass_TIME_AND_DATE_ADJUST : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput HOUR_UP;
        Crestron.Logos.SplusObjects.DigitalInput HOUR_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput MINUTE_UP;
        Crestron.Logos.SplusObjects.DigitalInput MINUTE_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput DAY_UP;
        Crestron.Logos.SplusObjects.DigitalInput DAY_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput MONTH_UP;
        Crestron.Logos.SplusObjects.DigitalInput MONTH_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput YEAR_UP;
        Crestron.Logos.SplusObjects.DigitalInput YEAR_DOWN;
        Crestron.Logos.SplusObjects.DigitalOutput TIME_CHANGED;
        ushort MONTHVAR = 0;
        ushort DAYVAR = 0;
        ushort YEARVAR = 0;
        ushort CURHOURS = 0;
        ushort CURMIN = 0;
        private void FNCURRENTDATE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 131;
            MONTHVAR = (ushort) ( Functions.GetMonthNum() ) ; 
            __context__.SourceCodeLine = 132;
            DAYVAR = (ushort) ( Functions.GetDateNum() ) ; 
            __context__.SourceCodeLine = 133;
            YEARVAR = (ushort) ( Functions.GetYearNum() ) ; 
            
            }
            
        private void FN31DAYSUP (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 140;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DAYVAR == 31))  ) ) 
                { 
                __context__.SourceCodeLine = 142;
                DAYVAR = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 146;
                DAYVAR = (ushort) ( (DAYVAR + 1) ) ; 
                } 
            
            
            }
            
        private void FN30DAYSUP (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 154;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DAYVAR == 30))  ) ) 
                { 
                __context__.SourceCodeLine = 156;
                DAYVAR = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 160;
                DAYVAR = (ushort) ( (DAYVAR + 1) ) ; 
                } 
            
            
            }
            
        private void FN31DAYSDN (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 168;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DAYVAR == 31))  ) ) 
                { 
                __context__.SourceCodeLine = 170;
                DAYVAR = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 174;
                DAYVAR = (ushort) ( (DAYVAR - 1) ) ; 
                } 
            
            
            }
            
        private void FN30DAYSDN (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 182;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DAYVAR == 30))  ) ) 
                { 
                __context__.SourceCodeLine = 184;
                DAYVAR = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 188;
                DAYVAR = (ushort) ( (DAYVAR - 1) ) ; 
                } 
            
            
            }
            
        object MONTH_UP_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 222;
                FNCURRENTDATE (  __context__  ) ; 
                __context__.SourceCodeLine = 224;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MONTHVAR == 12))  ) ) 
                    { 
                    __context__.SourceCodeLine = 226;
                    MONTHVAR = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 230;
                    MONTHVAR = (ushort) ( (MONTHVAR + 1) ) ; 
                    } 
                
                __context__.SourceCodeLine = 233;
                Functions.SetDate (  (int) ( MONTHVAR ) ,  (int) ( DAYVAR ) ,  (int) ( YEARVAR ) ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object MONTH_DOWN_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 240;
            FNCURRENTDATE (  __context__  ) ; 
            __context__.SourceCodeLine = 242;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MONTHVAR == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 244;
                MONTHVAR = (ushort) ( 12 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 248;
                MONTHVAR = (ushort) ( (MONTHVAR - 1) ) ; 
                } 
            
            __context__.SourceCodeLine = 251;
            Functions.SetDate (  (int) ( MONTHVAR ) ,  (int) ( DAYVAR ) ,  (int) ( YEARVAR ) ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object YEAR_UP_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 258;
        FNCURRENTDATE (  __context__  ) ; 
        __context__.SourceCodeLine = 260;
        YEARVAR = (ushort) ( (YEARVAR + 1) ) ; 
        __context__.SourceCodeLine = 262;
        Functions.SetDate (  (int) ( MONTHVAR ) ,  (int) ( DAYVAR ) ,  (int) ( YEARVAR ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object YEAR_DOWN_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 268;
        FNCURRENTDATE (  __context__  ) ; 
        __context__.SourceCodeLine = 270;
        YEARVAR = (ushort) ( (YEARVAR - 1) ) ; 
        __context__.SourceCodeLine = 272;
        Functions.SetDate (  (int) ( MONTHVAR ) ,  (int) ( DAYVAR ) ,  (int) ( YEARVAR ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DAY_UP_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 278;
        FNCURRENTDATE (  __context__  ) ; 
        __context__.SourceCodeLine = 280;
        
            {
            int __SPLS_TMPVAR__SWTCH_1__ = ((int)MONTHVAR);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 284;
                    FN31DAYSUP (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 288;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DAYVAR == 28))  ) ) 
                        { 
                        __context__.SourceCodeLine = 290;
                        DAYVAR = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 294;
                        DAYVAR = (ushort) ( (DAYVAR + 1) ) ; 
                        } 
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 300;
                    FN31DAYSUP (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 304;
                    FN30DAYSUP (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 308;
                    FN31DAYSUP (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 312;
                    FN30DAYSUP (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 316;
                    FN31DAYSUP (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 320;
                    FN31DAYSUP (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 9) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 324;
                    FN30DAYSUP (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 10) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 328;
                    FN30DAYSUP (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 11) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 332;
                    FN30DAYSUP (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 12) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 336;
                    FN31DAYSUP (  __context__  ) ; 
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 340;
        Functions.SetDate (  (int) ( MONTHVAR ) ,  (int) ( DAYVAR ) ,  (int) ( YEARVAR ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DAY_DOWN_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 348;
        FNCURRENTDATE (  __context__  ) ; 
        __context__.SourceCodeLine = 350;
        
            {
            int __SPLS_TMPVAR__SWTCH_2__ = ((int)MONTHVAR);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 354;
                    FN31DAYSDN (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 358;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DAYVAR == 28))  ) ) 
                        { 
                        __context__.SourceCodeLine = 360;
                        DAYVAR = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 364;
                        DAYVAR = (ushort) ( (DAYVAR - 1) ) ; 
                        } 
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 370;
                    FN31DAYSDN (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 374;
                    FN30DAYSDN (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 5) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 378;
                    FN31DAYSDN (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 6) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 382;
                    FN30DAYSDN (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 7) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 386;
                    FN31DAYSDN (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 8) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 390;
                    FN31DAYSDN (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 9) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 394;
                    FN30DAYSDN (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 10) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 398;
                    FN30DAYSDN (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 11) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 402;
                    FN30DAYSDN (  __context__  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 12) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 406;
                    FN31DAYSDN (  __context__  ) ; 
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 410;
        Functions.SetDate (  (int) ( MONTHVAR ) ,  (int) ( DAYVAR ) ,  (int) ( YEARVAR ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HOUR_UP_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 420;
        CURHOURS = (ushort) ( Functions.GetHourNum() ) ; 
        __context__.SourceCodeLine = 421;
        CURMIN = (ushort) ( Functions.GetMinutesNum() ) ; 
        __context__.SourceCodeLine = 423;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURHOURS == 23))  ) ) 
            { 
            __context__.SourceCodeLine = 425;
            CURHOURS = (ushort) ( 0 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 429;
            CURHOURS = (ushort) ( (CURHOURS + 1) ) ; 
            } 
        
        __context__.SourceCodeLine = 432;
        Functions.SetClock (  (int) ( CURHOURS ) ,  (int) ( CURMIN ) ,  (int) ( 0 ) ) ; 
        __context__.SourceCodeLine = 433;
        Functions.Pulse ( 50, TIME_CHANGED ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HOUR_DOWN_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 438;
        CURHOURS = (ushort) ( Functions.GetHourNum() ) ; 
        __context__.SourceCodeLine = 439;
        CURMIN = (ushort) ( Functions.GetMinutesNum() ) ; 
        __context__.SourceCodeLine = 441;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURHOURS == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 443;
            CURHOURS = (ushort) ( 23 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 447;
            CURHOURS = (ushort) ( (CURHOURS - 1) ) ; 
            } 
        
        __context__.SourceCodeLine = 450;
        Functions.SetClock (  (int) ( CURHOURS ) ,  (int) ( CURMIN ) ,  (int) ( 0 ) ) ; 
        __context__.SourceCodeLine = 451;
        Functions.Pulse ( 50, TIME_CHANGED ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MINUTE_UP_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 457;
        CURHOURS = (ushort) ( Functions.GetHourNum() ) ; 
        __context__.SourceCodeLine = 458;
        CURMIN = (ushort) ( Functions.GetMinutesNum() ) ; 
        __context__.SourceCodeLine = 460;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURMIN == 59))  ) ) 
            { 
            __context__.SourceCodeLine = 462;
            CURMIN = (ushort) ( 0 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 466;
            CURMIN = (ushort) ( (CURMIN + 1) ) ; 
            } 
        
        __context__.SourceCodeLine = 469;
        Functions.SetClock (  (int) ( CURHOURS ) ,  (int) ( CURMIN ) ,  (int) ( 0 ) ) ; 
        __context__.SourceCodeLine = 470;
        Functions.Pulse ( 50, TIME_CHANGED ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MINUTE_DOWN_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 476;
        CURHOURS = (ushort) ( Functions.GetHourNum() ) ; 
        __context__.SourceCodeLine = 477;
        CURMIN = (ushort) ( Functions.GetMinutesNum() ) ; 
        __context__.SourceCodeLine = 479;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURMIN == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 481;
            CURMIN = (ushort) ( 59 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 485;
            CURMIN = (ushort) ( (CURMIN - 1) ) ; 
            } 
        
        __context__.SourceCodeLine = 488;
        Functions.SetClock (  (int) ( CURHOURS ) ,  (int) ( CURMIN ) ,  (int) ( 0 ) ) ; 
        __context__.SourceCodeLine = 489;
        Functions.Pulse ( 50, TIME_CHANGED ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    HOUR_UP = new Crestron.Logos.SplusObjects.DigitalInput( HOUR_UP__DigitalInput__, this );
    m_DigitalInputList.Add( HOUR_UP__DigitalInput__, HOUR_UP );
    
    HOUR_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( HOUR_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( HOUR_DOWN__DigitalInput__, HOUR_DOWN );
    
    MINUTE_UP = new Crestron.Logos.SplusObjects.DigitalInput( MINUTE_UP__DigitalInput__, this );
    m_DigitalInputList.Add( MINUTE_UP__DigitalInput__, MINUTE_UP );
    
    MINUTE_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( MINUTE_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( MINUTE_DOWN__DigitalInput__, MINUTE_DOWN );
    
    DAY_UP = new Crestron.Logos.SplusObjects.DigitalInput( DAY_UP__DigitalInput__, this );
    m_DigitalInputList.Add( DAY_UP__DigitalInput__, DAY_UP );
    
    DAY_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( DAY_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( DAY_DOWN__DigitalInput__, DAY_DOWN );
    
    MONTH_UP = new Crestron.Logos.SplusObjects.DigitalInput( MONTH_UP__DigitalInput__, this );
    m_DigitalInputList.Add( MONTH_UP__DigitalInput__, MONTH_UP );
    
    MONTH_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( MONTH_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( MONTH_DOWN__DigitalInput__, MONTH_DOWN );
    
    YEAR_UP = new Crestron.Logos.SplusObjects.DigitalInput( YEAR_UP__DigitalInput__, this );
    m_DigitalInputList.Add( YEAR_UP__DigitalInput__, YEAR_UP );
    
    YEAR_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( YEAR_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( YEAR_DOWN__DigitalInput__, YEAR_DOWN );
    
    TIME_CHANGED = new Crestron.Logos.SplusObjects.DigitalOutput( TIME_CHANGED__DigitalOutput__, this );
    m_DigitalOutputList.Add( TIME_CHANGED__DigitalOutput__, TIME_CHANGED );
    
    
    MONTH_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( MONTH_UP_OnPush_0, false ) );
    MONTH_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( MONTH_DOWN_OnPush_1, false ) );
    YEAR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_UP_OnPush_2, false ) );
    YEAR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_DOWN_OnPush_3, false ) );
    DAY_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( DAY_UP_OnPush_4, false ) );
    DAY_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( DAY_DOWN_OnPush_5, false ) );
    HOUR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_6, false ) );
    HOUR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_DOWN_OnPush_7, false ) );
    MINUTE_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINUTE_UP_OnPush_8, false ) );
    MINUTE_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINUTE_DOWN_OnPush_9, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_TIME_AND_DATE_ADJUST ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint HOUR_UP__DigitalInput__ = 0;
const uint HOUR_DOWN__DigitalInput__ = 1;
const uint MINUTE_UP__DigitalInput__ = 2;
const uint MINUTE_DOWN__DigitalInput__ = 3;
const uint DAY_UP__DigitalInput__ = 4;
const uint DAY_DOWN__DigitalInput__ = 5;
const uint MONTH_UP__DigitalInput__ = 6;
const uint MONTH_DOWN__DigitalInput__ = 7;
const uint YEAR_UP__DigitalInput__ = 8;
const uint YEAR_DOWN__DigitalInput__ = 9;
const uint TIME_CHANGED__DigitalOutput__ = 0;

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
