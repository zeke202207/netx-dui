using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public sealed class DuiBrushes
    {
        private static DuiSolidBrush aliceblue => new DuiSolidBrush(Color.AliceBlue);
        private static DuiSolidBrush antiquewhite => new DuiSolidBrush(Color.AntiqueWhite);
        private static DuiSolidBrush aqua => new DuiSolidBrush(Color.Aqua);
        private static DuiSolidBrush aquamarine => new DuiSolidBrush(Color.Aquamarine);
        private static DuiSolidBrush azure => new DuiSolidBrush(Color.Azure);
        private static DuiSolidBrush beige => new DuiSolidBrush(Color.Beige);
        private static DuiSolidBrush bisque => new DuiSolidBrush(Color.Bisque);
        private static DuiSolidBrush black => new DuiSolidBrush(Color.Black);
        private static DuiSolidBrush blanchedalmond => new DuiSolidBrush(Color.BlanchedAlmond);
        private static DuiSolidBrush blue => new DuiSolidBrush(Color.Blue);
        private static DuiSolidBrush blueviolet => new DuiSolidBrush(Color.BlueViolet);
        private static DuiSolidBrush brown => new DuiSolidBrush(Color.Brown);
        private static DuiSolidBrush burlywood => new DuiSolidBrush(Color.BurlyWood);
        private static DuiSolidBrush cadetblue => new DuiSolidBrush(Color.CadetBlue);
        private static DuiSolidBrush chartreuse => new DuiSolidBrush(Color.Chartreuse);
        private static DuiSolidBrush chocolate => new DuiSolidBrush(Color.Chocolate);
        private static DuiSolidBrush coral => new DuiSolidBrush(Color.Coral);
        private static DuiSolidBrush cornflowerblue => new DuiSolidBrush(Color.CornflowerBlue);
        private static DuiSolidBrush cornsilk => new DuiSolidBrush(Color.Cornsilk);
        private static DuiSolidBrush crimson => new DuiSolidBrush(Color.Crimson);
        private static DuiSolidBrush cyan => new DuiSolidBrush(Color.Cyan);
        private static DuiSolidBrush darkblue => new DuiSolidBrush(Color.DarkBlue);
        private static DuiSolidBrush darkcyan => new DuiSolidBrush(Color.DarkCyan);
        private static DuiSolidBrush darkgoldenrod => new DuiSolidBrush(Color.DarkGoldenrod);
        private static DuiSolidBrush darkgray => new DuiSolidBrush(Color.DarkGray);
        private static DuiSolidBrush darkgreen => new DuiSolidBrush(Color.DarkGreen);
        private static DuiSolidBrush darkkhaki => new DuiSolidBrush(Color.DarkKhaki);
        private static DuiSolidBrush darkmagenta => new DuiSolidBrush(Color.DarkMagenta);
        private static DuiSolidBrush darkolivegreen => new DuiSolidBrush(Color.DarkOliveGreen);
        private static DuiSolidBrush darkorange => new DuiSolidBrush(Color.DarkOrange);
        private static DuiSolidBrush darkorchid => new DuiSolidBrush(Color.DarkOrchid);
        private static DuiSolidBrush darkred => new DuiSolidBrush(Color.DarkRed);
        private static DuiSolidBrush darksalmon => new DuiSolidBrush(Color.DarkSalmon);
        private static DuiSolidBrush darkseagreen => new DuiSolidBrush(Color.DarkSeaGreen);
        private static DuiSolidBrush darkslateblue => new DuiSolidBrush(Color.DarkSlateBlue);
        private static DuiSolidBrush darkslategray => new DuiSolidBrush(Color.DarkSlateGray);
        private static DuiSolidBrush darkturquoise => new DuiSolidBrush(Color.DarkTurquoise);
        private static DuiSolidBrush darkviolet => new DuiSolidBrush(Color.DarkViolet);
        private static DuiSolidBrush deeppink => new DuiSolidBrush(Color.DeepPink);
        private static DuiSolidBrush deepskyblue => new DuiSolidBrush(Color.DeepSkyBlue);
        private static DuiSolidBrush dimgray => new DuiSolidBrush(Color.DimGray);
        private static DuiSolidBrush dodgerblue => new DuiSolidBrush(Color.DodgerBlue);
        private static DuiSolidBrush firebrick => new DuiSolidBrush(Color.Firebrick);
        private static DuiSolidBrush floralwhite => new DuiSolidBrush(Color.FloralWhite);
        private static DuiSolidBrush forestgreen => new DuiSolidBrush(Color.ForestGreen);
        private static DuiSolidBrush fuchsia => new DuiSolidBrush(Color.Fuchsia);
        private static DuiSolidBrush gainsboro => new DuiSolidBrush(Color.Gainsboro);
        private static DuiSolidBrush ghostwhite => new DuiSolidBrush(Color.GhostWhite);
        private static DuiSolidBrush gold => new DuiSolidBrush(Color.Gold);
        private static DuiSolidBrush goldenrod => new DuiSolidBrush(Color.Goldenrod);
        private static DuiSolidBrush gray => new DuiSolidBrush(Color.Gray);
        private static DuiSolidBrush green => new DuiSolidBrush(Color.Green);
        private static DuiSolidBrush greenyellow => new DuiSolidBrush(Color.GreenYellow);
        private static DuiSolidBrush honeydew => new DuiSolidBrush(Color.Honeydew);
        private static DuiSolidBrush hotpink => new DuiSolidBrush(Color.HotPink);
        private static DuiSolidBrush indianred => new DuiSolidBrush(Color.IndianRed);
        private static DuiSolidBrush indigo => new DuiSolidBrush(Color.Indigo);
        private static DuiSolidBrush ivory => new DuiSolidBrush(Color.Ivory);
        private static DuiSolidBrush khaki => new DuiSolidBrush(Color.Khaki);
        private static DuiSolidBrush lavender => new DuiSolidBrush(Color.Lavender);
        private static DuiSolidBrush lavenderblush => new DuiSolidBrush(Color.LavenderBlush);
        private static DuiSolidBrush lawngreen => new DuiSolidBrush(Color.LawnGreen);
        private static DuiSolidBrush lemonchiffon => new DuiSolidBrush(Color.LemonChiffon);
        private static DuiSolidBrush lightblue => new DuiSolidBrush(Color.LightBlue);
        private static DuiSolidBrush lightcoral => new DuiSolidBrush(Color.LightCoral);
        private static DuiSolidBrush lightcyan => new DuiSolidBrush(Color.LightCyan);
        private static DuiSolidBrush lightgoldenrodyellow => new DuiSolidBrush(Color.LightGoldenrodYellow);
        private static DuiSolidBrush lightgray => new DuiSolidBrush(Color.LightGray);
        private static DuiSolidBrush lightgreen => new DuiSolidBrush(Color.LightGreen);
        private static DuiSolidBrush lightpink => new DuiSolidBrush(Color.LightPink);
        private static DuiSolidBrush lightsalmon => new DuiSolidBrush(Color.LightSalmon);
        private static DuiSolidBrush lightseagreen => new DuiSolidBrush(Color.LightSeaGreen);
        private static DuiSolidBrush lightskyblue => new DuiSolidBrush(Color.LightSkyBlue);
        private static DuiSolidBrush lightslategray => new DuiSolidBrush(Color.LightSlateGray);
        private static DuiSolidBrush lightsteelblue => new DuiSolidBrush(Color.LightSteelBlue);
        private static DuiSolidBrush lightyellow => new DuiSolidBrush(Color.LightYellow);
        private static DuiSolidBrush lime => new DuiSolidBrush(Color.Lime);
        private static DuiSolidBrush limegreen => new DuiSolidBrush(Color.LimeGreen);
        private static DuiSolidBrush linen => new DuiSolidBrush(Color.Linen);
        private static DuiSolidBrush magenta => new DuiSolidBrush(Color.Magenta);
        private static DuiSolidBrush maroon => new DuiSolidBrush(Color.Maroon);
        private static DuiSolidBrush mediumaquamarine => new DuiSolidBrush(Color.MediumAquamarine);
        private static DuiSolidBrush mediumblue => new DuiSolidBrush(Color.MediumBlue);
        private static DuiSolidBrush mediumorchid => new DuiSolidBrush(Color.MediumOrchid);
        private static DuiSolidBrush mediumpurple => new DuiSolidBrush(Color.MediumPurple);
        private static DuiSolidBrush mediumseagreen => new DuiSolidBrush(Color.MediumSeaGreen);
        private static DuiSolidBrush mediumslateblue => new DuiSolidBrush(Color.MediumSlateBlue);
        private static DuiSolidBrush mediumspringgreen => new DuiSolidBrush(Color.MediumSpringGreen);
        private static DuiSolidBrush mediumturquoise => new DuiSolidBrush(Color.MediumTurquoise);
        private static DuiSolidBrush mediumvioletred => new DuiSolidBrush(Color.MediumVioletRed);
        private static DuiSolidBrush midnightblue => new DuiSolidBrush(Color.MidnightBlue);
        private static DuiSolidBrush mintcream => new DuiSolidBrush(Color.MintCream);
        private static DuiSolidBrush mistyrose => new DuiSolidBrush(Color.MistyRose);
        private static DuiSolidBrush moccasin => new DuiSolidBrush(Color.Moccasin);
        private static DuiSolidBrush navajowhite => new DuiSolidBrush(Color.NavajoWhite);
        private static DuiSolidBrush navy => new DuiSolidBrush(Color.Navy);
        private static DuiSolidBrush oldlace => new DuiSolidBrush(Color.OldLace);
        private static DuiSolidBrush olive => new DuiSolidBrush(Color.Olive);
        private static DuiSolidBrush olivedrab => new DuiSolidBrush(Color.OliveDrab);
        private static DuiSolidBrush orange => new DuiSolidBrush(Color.Orange);
        private static DuiSolidBrush orangered => new DuiSolidBrush(Color.OrangeRed);
        private static DuiSolidBrush orchid => new DuiSolidBrush(Color.Orchid);
        private static DuiSolidBrush palegoldenrod => new DuiSolidBrush(Color.PaleGoldenrod);
        private static DuiSolidBrush palegreen => new DuiSolidBrush(Color.PaleGreen);
        private static DuiSolidBrush paleturquoise => new DuiSolidBrush(Color.PaleTurquoise);
        private static DuiSolidBrush palevioletred => new DuiSolidBrush(Color.PaleVioletRed);
        private static DuiSolidBrush papayawhip => new DuiSolidBrush(Color.PapayaWhip);
        private static DuiSolidBrush peachpuff => new DuiSolidBrush(Color.PeachPuff);
        private static DuiSolidBrush peru => new DuiSolidBrush(Color.Peru);
        private static DuiSolidBrush pink => new DuiSolidBrush(Color.Pink);
        private static DuiSolidBrush plum => new DuiSolidBrush(Color.Plum);
        private static DuiSolidBrush powderblue => new DuiSolidBrush(Color.PowderBlue);
        private static DuiSolidBrush purple => new DuiSolidBrush(Color.Purple);
        private static DuiSolidBrush red => new DuiSolidBrush(Color.Red);
        private static DuiSolidBrush rosybrown => new DuiSolidBrush(Color.RosyBrown);
        private static DuiSolidBrush royalblue => new DuiSolidBrush(Color.RoyalBlue);
        private static DuiSolidBrush saddlebrown => new DuiSolidBrush(Color.SaddleBrown);
        private static DuiSolidBrush salmon => new DuiSolidBrush(Color.Salmon);
        private static DuiSolidBrush sandybrown => new DuiSolidBrush(Color.SandyBrown);
        private static DuiSolidBrush seagreen => new DuiSolidBrush(Color.SeaGreen);
        private static DuiSolidBrush seashell => new DuiSolidBrush(Color.SeaShell);
        private static DuiSolidBrush sienna => new DuiSolidBrush(Color.Sienna);
        private static DuiSolidBrush silver => new DuiSolidBrush(Color.Silver);
        private static DuiSolidBrush skyblue => new DuiSolidBrush(Color.SkyBlue);
        private static DuiSolidBrush slateblue => new DuiSolidBrush(Color.SlateBlue);
        private static DuiSolidBrush slategray => new DuiSolidBrush(Color.SlateGray);
        private static DuiSolidBrush snow => new DuiSolidBrush(Color.Snow);
        private static DuiSolidBrush springgreen => new DuiSolidBrush(Color.SpringGreen);
        private static DuiSolidBrush steelblue => new DuiSolidBrush(Color.SteelBlue);
        private static DuiSolidBrush tan => new DuiSolidBrush(Color.Tan);
        private static DuiSolidBrush teal => new DuiSolidBrush(Color.Teal);
        private static DuiSolidBrush thistle => new DuiSolidBrush(Color.Thistle);
        private static DuiSolidBrush tomato => new DuiSolidBrush(Color.Tomato);
        private static DuiSolidBrush transparent => new DuiSolidBrush(Color.Transparent);
        private static DuiSolidBrush turquoise => new DuiSolidBrush(Color.Turquoise);
        private static DuiSolidBrush violet => new DuiSolidBrush(Color.Violet);
        private static DuiSolidBrush wheat => new DuiSolidBrush(Color.Wheat);
        private static DuiSolidBrush white => new DuiSolidBrush(Color.White);
        private static DuiSolidBrush whitesmoke => new DuiSolidBrush(Color.WhiteSmoke);
        private static DuiSolidBrush yellow => new DuiSolidBrush(Color.Yellow);
        private static DuiSolidBrush yellowgreen => new DuiSolidBrush(Color.YellowGreen);

        public static DuiSolidBrush AliceBlue { get { return aliceblue; } }
        public static DuiSolidBrush AntiqueWhite { get { return antiquewhite; } }
        public static DuiSolidBrush Aqua { get { return aqua; } }
        public static DuiSolidBrush Aquamarine { get { return aquamarine; } }
        public static DuiSolidBrush Azure { get { return azure; } }
        public static DuiSolidBrush Beige { get { return beige; } }
        public static DuiSolidBrush Bisque { get { return bisque; } }
        public static DuiSolidBrush Black { get { return black; } }
        public static DuiSolidBrush BlanchedAlmond { get { return blanchedalmond; } }
        public static DuiSolidBrush Blue { get { return blue; } }
        public static DuiSolidBrush BlueViolet { get { return blueviolet; } }
        public static DuiSolidBrush Brown { get { return brown; } }
        public static DuiSolidBrush BurlyWood { get { return burlywood; } }
        public static DuiSolidBrush CadetBlue { get { return cadetblue; } }
        public static DuiSolidBrush Chartreuse { get { return chartreuse; } }
        public static DuiSolidBrush Chocolate { get { return chocolate; } }
        public static DuiSolidBrush Coral { get { return coral; } }
        public static DuiSolidBrush CornflowerBlue { get { return cornflowerblue; } }
        public static DuiSolidBrush Cornsilk { get { return cornsilk; } }
        public static DuiSolidBrush Crimson { get { return crimson; } }
        public static DuiSolidBrush Cyan { get { return cyan; } }
        public static DuiSolidBrush DarkBlue { get { return darkblue; } }
        public static DuiSolidBrush DarkCyan { get { return darkcyan; } }
        public static DuiSolidBrush DarkGoldenrod { get { return darkgoldenrod; } }
        public static DuiSolidBrush DarkGray { get { return darkgray; } }
        public static DuiSolidBrush DarkGreen { get { return darkgreen; } }
        public static DuiSolidBrush DarkKhaki { get { return darkkhaki; } }
        public static DuiSolidBrush DarkMagenta { get { return darkmagenta; } }
        public static DuiSolidBrush DarkOliveGreen { get { return darkolivegreen; } }
        public static DuiSolidBrush DarkOrange { get { return darkorange; } }
        public static DuiSolidBrush DarkOrchid { get { return darkorchid; } }
        public static DuiSolidBrush DarkRed { get { return darkred; } }
        public static DuiSolidBrush DarkSalmon { get { return darksalmon; } }
        public static DuiSolidBrush DarkSeaGreen { get { return darkseagreen; } }
        public static DuiSolidBrush DarkSlateBlue { get { return darkslateblue; } }
        public static DuiSolidBrush DarkSlateGray { get { return darkslategray; } }
        public static DuiSolidBrush DarkTurquoise { get { return darkturquoise; } }
        public static DuiSolidBrush DarkViolet { get { return darkviolet; } }
        public static DuiSolidBrush DeepPink { get { return deeppink; } }
        public static DuiSolidBrush DeepSkyBlue { get { return deepskyblue; } }
        public static DuiSolidBrush DimGray { get { return dimgray; } }
        public static DuiSolidBrush DodgerBlue { get { return dodgerblue; } }
        public static DuiSolidBrush Firebrick { get { return firebrick; } }
        public static DuiSolidBrush FloralWhite { get { return floralwhite; } }
        public static DuiSolidBrush ForestGreen { get { return forestgreen; } }
        public static DuiSolidBrush Fuchsia { get { return fuchsia; } }
        public static DuiSolidBrush Gainsboro { get { return gainsboro; } }
        public static DuiSolidBrush GhostWhite { get { return ghostwhite; } }
        public static DuiSolidBrush Gold { get { return gold; } }
        public static DuiSolidBrush Goldenrod { get { return goldenrod; } }
        public static DuiSolidBrush Gray { get { return gray; } }
        public static DuiSolidBrush Green { get { return green; } }
        public static DuiSolidBrush GreenYellow { get { return greenyellow; } }
        public static DuiSolidBrush Honeydew { get { return honeydew; } }
        public static DuiSolidBrush HotPink { get { return hotpink; } }
        public static DuiSolidBrush IndianRed { get { return indianred; } }
        public static DuiSolidBrush Indigo { get { return indigo; } }
        public static DuiSolidBrush Ivory { get { return ivory; } }
        public static DuiSolidBrush Khaki { get { return khaki; } }
        public static DuiSolidBrush Lavender { get { return lavender; } }
        public static DuiSolidBrush LavenderBlush { get { return lavenderblush; } }
        public static DuiSolidBrush LawnGreen { get { return lawngreen; } }
        public static DuiSolidBrush LemonChiffon { get { return lemonchiffon; } }
        public static DuiSolidBrush LightBlue { get { return lightblue; } }
        public static DuiSolidBrush LightCoral { get { return lightcoral; } }
        public static DuiSolidBrush LightCyan { get { return lightcyan; } }
        public static DuiSolidBrush LightGoldenrodYellow { get { return lightgoldenrodyellow; } }
        public static DuiSolidBrush LightGray { get { return lightgray; } }
        public static DuiSolidBrush LightGreen { get { return lightgreen; } }
        public static DuiSolidBrush LightPink { get { return lightpink; } }
        public static DuiSolidBrush LightSalmon { get { return lightsalmon; } }
        public static DuiSolidBrush LightSeaGreen { get { return lightseagreen; } }
        public static DuiSolidBrush LightSkyBlue { get { return lightskyblue; } }
        public static DuiSolidBrush LightSlateGray { get { return lightslategray; } }
        public static DuiSolidBrush LightSteelBlue { get { return lightsteelblue; } }
        public static DuiSolidBrush LightYellow { get { return lightyellow; } }
        public static DuiSolidBrush Lime { get { return lime; } }
        public static DuiSolidBrush LimeGreen { get { return limegreen; } }
        public static DuiSolidBrush Linen { get { return linen; } }
        public static DuiSolidBrush Magenta { get { return magenta; } }
        public static DuiSolidBrush Maroon { get { return maroon; } }
        public static DuiSolidBrush MediumAquamarine { get { return mediumaquamarine; } }
        public static DuiSolidBrush MediumBlue { get { return mediumblue; } }
        public static DuiSolidBrush MediumOrchid { get { return mediumorchid; } }
        public static DuiSolidBrush MediumPurple { get { return mediumpurple; } }
        public static DuiSolidBrush MediumSeaGreen { get { return mediumseagreen; } }
        public static DuiSolidBrush MediumSlateBlue { get { return mediumslateblue; } }
        public static DuiSolidBrush MediumSpringGreen { get { return mediumspringgreen; } }
        public static DuiSolidBrush MediumTurquoise { get { return mediumturquoise; } }
        public static DuiSolidBrush MediumVioletRed { get { return mediumvioletred; } }
        public static DuiSolidBrush MidnightBlue { get { return midnightblue; } }
        public static DuiSolidBrush MintCream { get { return mintcream; } }
        public static DuiSolidBrush MistyRose { get { return mistyrose; } }
        public static DuiSolidBrush Moccasin { get { return moccasin; } }
        public static DuiSolidBrush NavajoWhite { get { return navajowhite; } }
        public static DuiSolidBrush Navy { get { return navy; } }
        public static DuiSolidBrush OldLace { get { return oldlace; } }
        public static DuiSolidBrush Olive { get { return olive; } }
        public static DuiSolidBrush OliveDrab { get { return olivedrab; } }
        public static DuiSolidBrush Orange { get { return orange; } }
        public static DuiSolidBrush OrangeRed { get { return orangered; } }
        public static DuiSolidBrush Orchid { get { return orchid; } }
        public static DuiSolidBrush PaleGoldenrod { get { return palegoldenrod; } }
        public static DuiSolidBrush PaleGreen { get { return palegreen; } }
        public static DuiSolidBrush PaleTurquoise { get { return paleturquoise; } }
        public static DuiSolidBrush PaleVioletRed { get { return palevioletred; } }
        public static DuiSolidBrush PapayaWhip { get { return papayawhip; } }
        public static DuiSolidBrush PeachPuff { get { return peachpuff; } }
        public static DuiSolidBrush Peru { get { return peru; } }
        public static DuiSolidBrush Pink { get { return pink; } }
        public static DuiSolidBrush Plum { get { return plum; } }
        public static DuiSolidBrush PowderBlue { get { return powderblue; } }
        public static DuiSolidBrush Purple { get { return purple; } }
        public static DuiSolidBrush Red { get { return red; } }
        public static DuiSolidBrush RosyBrown { get { return rosybrown; } }
        public static DuiSolidBrush RoyalBlue { get { return royalblue; } }
        public static DuiSolidBrush SaddleBrown { get { return saddlebrown; } }
        public static DuiSolidBrush Salmon { get { return salmon; } }
        public static DuiSolidBrush SandyBrown { get { return sandybrown; } }
        public static DuiSolidBrush SeaGreen { get { return seagreen; } }
        public static DuiSolidBrush SeaShell { get { return seashell; } }
        public static DuiSolidBrush Sienna { get { return sienna; } }
        public static DuiSolidBrush Silver { get { return silver; } }
        public static DuiSolidBrush SkyBlue { get { return skyblue; } }
        public static DuiSolidBrush SlateBlue { get { return slateblue; } }
        public static DuiSolidBrush SlateGray { get { return slategray; } }
        public static DuiSolidBrush Snow { get { return snow; } }
        public static DuiSolidBrush SpringGreen { get { return springgreen; } }
        public static DuiSolidBrush SteelBlue { get { return steelblue; } }
        public static DuiSolidBrush Tan { get { return tan; } }
        public static DuiSolidBrush Teal { get { return teal; } }
        public static DuiSolidBrush Thistle { get { return thistle; } }
        public static DuiSolidBrush Tomato { get { return tomato; } }
        public static DuiSolidBrush Transparent { get { return transparent; } }
        public static DuiSolidBrush Turquoise { get { return turquoise; } }
        public static DuiSolidBrush Violet { get { return violet; } }
        public static DuiSolidBrush Wheat { get { return wheat; } }
        public static DuiSolidBrush White { get { return white; } }
        public static DuiSolidBrush WhiteSmoke { get { return whitesmoke; } }
        public static DuiSolidBrush Yellow { get { return yellow; } }
        public static DuiSolidBrush YellowGreen { get { return yellowgreen; } }
    }
}
