using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public sealed class DuiPens
    {
        private static DuiPen aliceblue => new DuiPen(Color.AliceBlue);
        private static DuiPen antiquewhite => new DuiPen(Color.AntiqueWhite);
        private static DuiPen aqua => new DuiPen(Color.Aqua);
        private static DuiPen aquamarine => new DuiPen(Color.Aquamarine);
        private static DuiPen azure => new DuiPen(Color.Azure);
        private static DuiPen beige => new DuiPen(Color.Beige);
        private static DuiPen bisque => new DuiPen(Color.Bisque);
        private static DuiPen black => new DuiPen(Color.Black);
        private static DuiPen blanchedalmond => new DuiPen(Color.BlanchedAlmond);
        private static DuiPen blue => new DuiPen(Color.Blue);
        private static DuiPen blueviolet => new DuiPen(Color.BlueViolet);
        private static DuiPen brown => new DuiPen(Color.Brown);
        private static DuiPen burlywood => new DuiPen(Color.BurlyWood);
        private static DuiPen cadetblue => new DuiPen(Color.CadetBlue);
        private static DuiPen chartreuse => new DuiPen(Color.Chartreuse);
        private static DuiPen chocolate => new DuiPen(Color.Chocolate);
        private static DuiPen coral => new DuiPen(Color.Coral);
        private static DuiPen cornflowerblue => new DuiPen(Color.CornflowerBlue);
        private static DuiPen cornsilk => new DuiPen(Color.Cornsilk);
        private static DuiPen crimson => new DuiPen(Color.Crimson);
        private static DuiPen cyan => new DuiPen(Color.Cyan);
        private static DuiPen darkblue => new DuiPen(Color.DarkBlue);
        private static DuiPen darkcyan => new DuiPen(Color.DarkCyan);
        private static DuiPen darkgoldenrod => new DuiPen(Color.DarkGoldenrod);
        private static DuiPen darkgray => new DuiPen(Color.DarkGray);
        private static DuiPen darkgreen => new DuiPen(Color.DarkGreen);
        private static DuiPen darkkhaki => new DuiPen(Color.DarkKhaki);
        private static DuiPen darkmagenta => new DuiPen(Color.DarkMagenta);
        private static DuiPen darkolivegreen => new DuiPen(Color.DarkOliveGreen);
        private static DuiPen darkorange => new DuiPen(Color.DarkOrange);
        private static DuiPen darkorchid => new DuiPen(Color.DarkOrchid);
        private static DuiPen darkred => new DuiPen(Color.DarkRed);
        private static DuiPen darksalmon => new DuiPen(Color.DarkSalmon);
        private static DuiPen darkseagreen => new DuiPen(Color.DarkSeaGreen);
        private static DuiPen darkslateblue => new DuiPen(Color.DarkSlateBlue);
        private static DuiPen darkslategray => new DuiPen(Color.DarkSlateGray);
        private static DuiPen darkturquoise => new DuiPen(Color.DarkTurquoise);
        private static DuiPen darkviolet => new DuiPen(Color.DarkViolet);
        private static DuiPen deeppink => new DuiPen(Color.DeepPink);
        private static DuiPen deepskyblue => new DuiPen(Color.DeepSkyBlue);
        private static DuiPen dimgray => new DuiPen(Color.DimGray);
        private static DuiPen dodgerblue => new DuiPen(Color.DodgerBlue);
        private static DuiPen firebrick => new DuiPen(Color.Firebrick);
        private static DuiPen floralwhite => new DuiPen(Color.FloralWhite);
        private static DuiPen forestgreen => new DuiPen(Color.ForestGreen);
        private static DuiPen fuchsia => new DuiPen(Color.Fuchsia);
        private static DuiPen gainsboro => new DuiPen(Color.Gainsboro);
        private static DuiPen ghostwhite => new DuiPen(Color.GhostWhite);
        private static DuiPen gold => new DuiPen(Color.Gold);
        private static DuiPen goldenrod => new DuiPen(Color.Goldenrod);
        private static DuiPen gray => new DuiPen(Color.Gray);
        private static DuiPen green => new DuiPen(Color.Green);
        private static DuiPen greenyellow => new DuiPen(Color.GreenYellow);
        private static DuiPen honeydew => new DuiPen(Color.Honeydew);
        private static DuiPen hotpink => new DuiPen(Color.HotPink);
        private static DuiPen indianred => new DuiPen(Color.IndianRed);
        private static DuiPen indigo => new DuiPen(Color.Indigo);
        private static DuiPen ivory => new DuiPen(Color.Ivory);
        private static DuiPen khaki => new DuiPen(Color.Khaki);
        private static DuiPen lavender => new DuiPen(Color.Lavender);
        private static DuiPen lavenderblush => new DuiPen(Color.LavenderBlush);
        private static DuiPen lawngreen => new DuiPen(Color.LawnGreen);
        private static DuiPen lemonchiffon => new DuiPen(Color.LemonChiffon);
        private static DuiPen lightblue => new DuiPen(Color.LightBlue);
        private static DuiPen lightcoral => new DuiPen(Color.LightCoral);
        private static DuiPen lightcyan => new DuiPen(Color.LightCyan);
        private static DuiPen lightgoldenrodyellow => new DuiPen(Color.LightGoldenrodYellow);
        private static DuiPen lightgray => new DuiPen(Color.LightGray);
        private static DuiPen lightgreen => new DuiPen(Color.LightGreen);
        private static DuiPen lightpink => new DuiPen(Color.LightPink);
        private static DuiPen lightsalmon => new DuiPen(Color.LightSalmon);
        private static DuiPen lightseagreen => new DuiPen(Color.LightSeaGreen);
        private static DuiPen lightskyblue => new DuiPen(Color.LightSkyBlue);
        private static DuiPen lightslategray => new DuiPen(Color.LightSlateGray);
        private static DuiPen lightsteelblue => new DuiPen(Color.LightSteelBlue);
        private static DuiPen lightyellow => new DuiPen(Color.LightYellow);
        private static DuiPen lime => new DuiPen(Color.Lime);
        private static DuiPen limegreen => new DuiPen(Color.LimeGreen);
        private static DuiPen linen => new DuiPen(Color.Linen);
        private static DuiPen magenta => new DuiPen(Color.Magenta);
        private static DuiPen maroon => new DuiPen(Color.Maroon);
        private static DuiPen mediumaquamarine => new DuiPen(Color.MediumAquamarine);
        private static DuiPen mediumblue => new DuiPen(Color.MediumBlue);
        private static DuiPen mediumorchid => new DuiPen(Color.MediumOrchid);
        private static DuiPen mediumpurple => new DuiPen(Color.MediumPurple);
        private static DuiPen mediumseagreen => new DuiPen(Color.MediumSeaGreen);
        private static DuiPen mediumslateblue => new DuiPen(Color.MediumSlateBlue);
        private static DuiPen mediumspringgreen => new DuiPen(Color.MediumSpringGreen);
        private static DuiPen mediumturquoise => new DuiPen(Color.MediumTurquoise);
        private static DuiPen mediumvioletred => new DuiPen(Color.MediumVioletRed);
        private static DuiPen midnightblue => new DuiPen(Color.MidnightBlue);
        private static DuiPen mintcream => new DuiPen(Color.MintCream);
        private static DuiPen mistyrose => new DuiPen(Color.MistyRose);
        private static DuiPen moccasin => new DuiPen(Color.Moccasin);
        private static DuiPen navajowhite => new DuiPen(Color.NavajoWhite);
        private static DuiPen navy => new DuiPen(Color.Navy);
        private static DuiPen oldlace => new DuiPen(Color.OldLace);
        private static DuiPen olive => new DuiPen(Color.Olive);
        private static DuiPen olivedrab => new DuiPen(Color.OliveDrab);
        private static DuiPen orange => new DuiPen(Color.Orange);
        private static DuiPen orangered => new DuiPen(Color.OrangeRed);
        private static DuiPen orchid => new DuiPen(Color.Orchid);
        private static DuiPen palegoldenrod => new DuiPen(Color.PaleGoldenrod);
        private static DuiPen palegreen => new DuiPen(Color.PaleGreen);
        private static DuiPen paleturquoise => new DuiPen(Color.PaleTurquoise);
        private static DuiPen palevioletred => new DuiPen(Color.PaleVioletRed);
        private static DuiPen papayawhip => new DuiPen(Color.PapayaWhip);
        private static DuiPen peachpuff => new DuiPen(Color.PeachPuff);
        private static DuiPen peru => new DuiPen(Color.Peru);
        private static DuiPen pink => new DuiPen(Color.Pink);
        private static DuiPen plum => new DuiPen(Color.Plum);
        private static DuiPen powderblue => new DuiPen(Color.PowderBlue);
        private static DuiPen purple => new DuiPen(Color.Purple);
        private static DuiPen red => new DuiPen(Color.Red);
        private static DuiPen rosybrown => new DuiPen(Color.RosyBrown);
        private static DuiPen royalblue => new DuiPen(Color.RoyalBlue);
        private static DuiPen saddlebrown => new DuiPen(Color.SaddleBrown);
        private static DuiPen salmon => new DuiPen(Color.Salmon);
        private static DuiPen sandybrown => new DuiPen(Color.SandyBrown);
        private static DuiPen seagreen => new DuiPen(Color.SeaGreen);
        private static DuiPen seashell => new DuiPen(Color.SeaShell);
        private static DuiPen sienna => new DuiPen(Color.Sienna);
        private static DuiPen silver => new DuiPen(Color.Silver);
        private static DuiPen skyblue => new DuiPen(Color.SkyBlue);
        private static DuiPen slateblue => new DuiPen(Color.SlateBlue);
        private static DuiPen slategray => new DuiPen(Color.SlateGray);
        private static DuiPen snow => new DuiPen(Color.Snow);
        private static DuiPen springgreen => new DuiPen(Color.SpringGreen);
        private static DuiPen steelblue => new DuiPen(Color.SteelBlue);
        private static DuiPen tan => new DuiPen(Color.Tan);
        private static DuiPen teal => new DuiPen(Color.Teal);
        private static DuiPen thistle => new DuiPen(Color.Thistle);
        private static DuiPen tomato => new DuiPen(Color.Tomato);
        private static DuiPen transparent => new DuiPen(Color.Transparent);
        private static DuiPen turquoise => new DuiPen(Color.Turquoise);
        private static DuiPen violet => new DuiPen(Color.Violet);
        private static DuiPen wheat => new DuiPen(Color.Wheat);
        private static DuiPen white => new DuiPen(Color.White);
        private static DuiPen whitesmoke => new DuiPen(Color.WhiteSmoke);
        private static DuiPen yellow => new DuiPen(Color.Yellow);
        private static DuiPen yellowgreen => new DuiPen(Color.YellowGreen);

        public static DuiPen AliceBlue { get { return aliceblue; } }
        public static DuiPen AntiqueWhite { get { return antiquewhite; } }
        public static DuiPen Aqua { get { return aqua; } }
        public static DuiPen Aquamarine { get { return aquamarine; } }
        public static DuiPen Azure { get { return azure; } }
        public static DuiPen Beige { get { return beige; } }
        public static DuiPen Bisque { get { return bisque; } }
        public static DuiPen Black { get { return black; } }
        public static DuiPen BlanchedAlmond { get { return blanchedalmond; } }
        public static DuiPen Blue { get { return blue; } }
        public static DuiPen BlueViolet { get { return blueviolet; } }
        public static DuiPen Brown { get { return brown; } }
        public static DuiPen BurlyWood { get { return burlywood; } }
        public static DuiPen CadetBlue { get { return cadetblue; } }
        public static DuiPen Chartreuse { get { return chartreuse; } }
        public static DuiPen Chocolate { get { return chocolate; } }
        public static DuiPen Coral { get { return coral; } }
        public static DuiPen CornflowerBlue { get { return cornflowerblue; } }
        public static DuiPen Cornsilk { get { return cornsilk; } }
        public static DuiPen Crimson { get { return crimson; } }
        public static DuiPen Cyan { get { return cyan; } }
        public static DuiPen DarkBlue { get { return darkblue; } }
        public static DuiPen DarkCyan { get { return darkcyan; } }
        public static DuiPen DarkGoldenrod { get { return darkgoldenrod; } }
        public static DuiPen DarkGray { get { return darkgray; } }
        public static DuiPen DarkGreen { get { return darkgreen; } }
        public static DuiPen DarkKhaki { get { return darkkhaki; } }
        public static DuiPen DarkMagenta { get { return darkmagenta; } }
        public static DuiPen DarkOliveGreen { get { return darkolivegreen; } }
        public static DuiPen DarkOrange { get { return darkorange; } }
        public static DuiPen DarkOrchid { get { return darkorchid; } }
        public static DuiPen DarkRed { get { return darkred; } }
        public static DuiPen DarkSalmon { get { return darksalmon; } }
        public static DuiPen DarkSeaGreen { get { return darkseagreen; } }
        public static DuiPen DarkSlateBlue { get { return darkslateblue; } }
        public static DuiPen DarkSlateGray { get { return darkslategray; } }
        public static DuiPen DarkTurquoise { get { return darkturquoise; } }
        public static DuiPen DarkViolet { get { return darkviolet; } }
        public static DuiPen DeepPink { get { return deeppink; } }
        public static DuiPen DeepSkyBlue { get { return deepskyblue; } }
        public static DuiPen DimGray { get { return dimgray; } }
        public static DuiPen DodgerBlue { get { return dodgerblue; } }
        public static DuiPen Firebrick { get { return firebrick; } }
        public static DuiPen FloralWhite { get { return floralwhite; } }
        public static DuiPen ForestGreen { get { return forestgreen; } }
        public static DuiPen Fuchsia { get { return fuchsia; } }
        public static DuiPen Gainsboro { get { return gainsboro; } }
        public static DuiPen GhostWhite { get { return ghostwhite; } }
        public static DuiPen Gold { get { return gold; } }
        public static DuiPen Goldenrod { get { return goldenrod; } }
        public static DuiPen Gray { get { return gray; } }
        public static DuiPen Green { get { return green; } }
        public static DuiPen GreenYellow { get { return greenyellow; } }
        public static DuiPen Honeydew { get { return honeydew; } }
        public static DuiPen HotPink { get { return hotpink; } }
        public static DuiPen IndianRed { get { return indianred; } }
        public static DuiPen Indigo { get { return indigo; } }
        public static DuiPen Ivory { get { return ivory; } }
        public static DuiPen Khaki { get { return khaki; } }
        public static DuiPen Lavender { get { return lavender; } }
        public static DuiPen LavenderBlush { get { return lavenderblush; } }
        public static DuiPen LawnGreen { get { return lawngreen; } }
        public static DuiPen LemonChiffon { get { return lemonchiffon; } }
        public static DuiPen LightBlue { get { return lightblue; } }
        public static DuiPen LightCoral { get { return lightcoral; } }
        public static DuiPen LightCyan { get { return lightcyan; } }
        public static DuiPen LightGoldenrodYellow { get { return lightgoldenrodyellow; } }
        public static DuiPen LightGray { get { return lightgray; } }
        public static DuiPen LightGreen { get { return lightgreen; } }
        public static DuiPen LightPink { get { return lightpink; } }
        public static DuiPen LightSalmon { get { return lightsalmon; } }
        public static DuiPen LightSeaGreen { get { return lightseagreen; } }
        public static DuiPen LightSkyBlue { get { return lightskyblue; } }
        public static DuiPen LightSlateGray { get { return lightslategray; } }
        public static DuiPen LightSteelBlue { get { return lightsteelblue; } }
        public static DuiPen LightYellow { get { return lightyellow; } }
        public static DuiPen Lime { get { return lime; } }
        public static DuiPen LimeGreen { get { return limegreen; } }
        public static DuiPen Linen { get { return linen; } }
        public static DuiPen Magenta { get { return magenta; } }
        public static DuiPen Maroon { get { return maroon; } }
        public static DuiPen MediumAquamarine { get { return mediumaquamarine; } }
        public static DuiPen MediumBlue { get { return mediumblue; } }
        public static DuiPen MediumOrchid { get { return mediumorchid; } }
        public static DuiPen MediumPurple { get { return mediumpurple; } }
        public static DuiPen MediumSeaGreen { get { return mediumseagreen; } }
        public static DuiPen MediumSlateBlue { get { return mediumslateblue; } }
        public static DuiPen MediumSpringGreen { get { return mediumspringgreen; } }
        public static DuiPen MediumTurquoise { get { return mediumturquoise; } }
        public static DuiPen MediumVioletRed { get { return mediumvioletred; } }
        public static DuiPen MidnightBlue { get { return midnightblue; } }
        public static DuiPen MintCream { get { return mintcream; } }
        public static DuiPen MistyRose { get { return mistyrose; } }
        public static DuiPen Moccasin { get { return moccasin; } }
        public static DuiPen NavajoWhite { get { return navajowhite; } }
        public static DuiPen Navy { get { return navy; } }
        public static DuiPen OldLace { get { return oldlace; } }
        public static DuiPen Olive { get { return olive; } }
        public static DuiPen OliveDrab { get { return olivedrab; } }
        public static DuiPen Orange { get { return orange; } }
        public static DuiPen OrangeRed { get { return orangered; } }
        public static DuiPen Orchid { get { return orchid; } }
        public static DuiPen PaleGoldenrod { get { return palegoldenrod; } }
        public static DuiPen PaleGreen { get { return palegreen; } }
        public static DuiPen PaleTurquoise { get { return paleturquoise; } }
        public static DuiPen PaleVioletRed { get { return palevioletred; } }
        public static DuiPen PapayaWhip { get { return papayawhip; } }
        public static DuiPen PeachPuff { get { return peachpuff; } }
        public static DuiPen Peru { get { return peru; } }
        public static DuiPen Pink { get { return pink; } }
        public static DuiPen Plum { get { return plum; } }
        public static DuiPen PowderBlue { get { return powderblue; } }
        public static DuiPen Purple { get { return purple; } }
        public static DuiPen Red { get { return red; } }
        public static DuiPen RosyBrown { get { return rosybrown; } }
        public static DuiPen RoyalBlue { get { return royalblue; } }
        public static DuiPen SaddleBrown { get { return saddlebrown; } }
        public static DuiPen Salmon { get { return salmon; } }
        public static DuiPen SandyBrown { get { return sandybrown; } }
        public static DuiPen SeaGreen { get { return seagreen; } }
        public static DuiPen SeaShell { get { return seashell; } }
        public static DuiPen Sienna { get { return sienna; } }
        public static DuiPen Silver { get { return silver; } }
        public static DuiPen SkyBlue { get { return skyblue; } }
        public static DuiPen SlateBlue { get { return slateblue; } }
        public static DuiPen SlateGray { get { return slategray; } }
        public static DuiPen Snow { get { return snow; } }
        public static DuiPen SpringGreen { get { return springgreen; } }
        public static DuiPen SteelBlue { get { return steelblue; } }
        public static DuiPen Tan { get { return tan; } }
        public static DuiPen Teal { get { return teal; } }
        public static DuiPen Thistle { get { return thistle; } }
        public static DuiPen Tomato { get { return tomato; } }
        public static DuiPen Transparent { get { return transparent; } }
        public static DuiPen Turquoise { get { return turquoise; } }
        public static DuiPen Violet { get { return violet; } }
        public static DuiPen Wheat { get { return wheat; } }
        public static DuiPen White { get { return white; } }
        public static DuiPen WhiteSmoke { get { return whitesmoke; } }
        public static DuiPen Yellow { get { return yellow; } }
        public static DuiPen YellowGreen { get { return yellowgreen; } }
    }
}
