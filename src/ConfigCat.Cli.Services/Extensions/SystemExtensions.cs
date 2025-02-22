﻿using ConfigCat.Cli.Services;
using System.CommandLine.Rendering;

namespace System
{
    public static class SystemExtensions
    {
        public static TextSpan Underline(this string value) =>
               new ContainerSpan(StyleSpan.UnderlinedOn(),
                                 new ContentSpan(value),
                                 StyleSpan.UnderlinedOff());

        public static TextSpan Bold(this string value) =>
            new ContainerSpan(StyleSpan.BoldOn(),
                              new ContentSpan(value),
                              StyleSpan.BoldOff());

        public static TextSpan Standout(this string value) =>
            new ContainerSpan(StyleSpan.StandoutOn(),
                              new ContentSpan(value),
                              StyleSpan.StandoutOff());

        public static TextSpan Reverse(this string value) =>
            new ContainerSpan(StyleSpan.ReverseOn(),
                      new ContentSpan(value),
                      StyleSpan.ReverseOff());

        public static TextSpan Blink(this string value) =>
            new ContainerSpan(StyleSpan.BlinkOn(),
                      new ContentSpan(value),
                      StyleSpan.BlinkOff());

        public static TextSpan Color(this string value, ForegroundColorSpan span) =>
            new ContainerSpan(span, new ContentSpan(value), ForegroundColorSpan.Reset());

        public static TextSpan Background(this string value, BackgroundColorSpan span) =>
            new ContainerSpan(span, new ContentSpan(value), BackgroundColorSpan.Reset());

        public static TextSpan ColorWithBackground(this string value, ForegroundColorSpan foreground, BackgroundColorSpan background) =>
            new ContainerSpan(background, foreground, new ContentSpan(value), ForegroundColorSpan.Reset(), BackgroundColorSpan.Reset());

        public static bool IsEmpty(this string value) =>
            string.IsNullOrWhiteSpace(value);

        public static bool IsEmptyOrEquals(this string value, string other) =>
            string.IsNullOrWhiteSpace(value) || value.Equals(other);

        public static bool TryParseFlagValue(this string value, string settingType, out object parsed)
        {
            parsed = null;
            switch (settingType)
            {
                case SettingTypes.Boolean:
                    if (!bool.TryParse(value, out var boolParsed)) return false;
                    parsed = boolParsed;
                    return true;
                case SettingTypes.Int:
                    if (!int.TryParse(value, out var intParsed)) return false;
                    parsed = intParsed;
                    return true;
                case SettingTypes.Double:
                    if (!double.TryParse(value, out var doubleParsed)) return false;
                    parsed = doubleParsed;
                    return true;
                case SettingTypes.String:
                    parsed = value;
                    return true;
                default:
                    return false;
            }
        }
    }
}