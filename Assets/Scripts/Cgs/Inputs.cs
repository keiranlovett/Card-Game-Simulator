/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using System;
using UnityEngine;

namespace Cgs
{
    public static class Inputs
    {
        public const float Tolerance = 0.1f;
        public const KeyCode BluetoothReturn = (KeyCode) 10;
        public const string Cancel = "Cancel";
        public const string Filter = "Filter";
        public const string FocusBack = "FocusBack";
        public const string FocusNext = "FocusNext";
        public const string Horizontal = "Horizontal";
        public const string Load = "Load";
        public const string New = "New";
        public const string Option = "Option";
        public const string PageHorizontal = "PageHorizontal";
        public const string PageVertical = "PageVertical";
        public const string Save = "Save";
        public const string Sort = "Sort";
        public const string Submit = "Submit";
        public const string Vertical = "Vertical";

        public static bool IsCancel => Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown(Cancel);

        public static bool IsFilter => Input.GetButtonDown(Filter);

        public static bool IsFocus => Input.GetButtonDown(FocusBack) || Math.Abs(Input.GetAxis(FocusBack)) > Tolerance
                                                                     || Input.GetButtonDown(FocusNext) ||
                                                                     Math.Abs(Input.GetAxis(FocusNext)) > Tolerance;

        public static bool IsFocusBack =>
            Input.GetButtonDown(FocusBack) || Math.Abs(Input.GetAxis(FocusBack)) > Tolerance;

        public static bool IsFocusNext =>
            Input.GetButtonDown(FocusNext) || Math.Abs(Input.GetAxis(FocusNext)) > Tolerance;

        public static bool IsHorizontal =>
            Input.GetButton(Horizontal) || Math.Abs(Input.GetAxis(Horizontal)) > Tolerance;

        public static bool IsLeft => Input.GetAxis(Horizontal) < 0;
        public static bool IsRight => Input.GetAxis(Horizontal) > 0;

        public static bool IsLoad => Input.GetButtonDown(Load);

        public static bool IsNew => Input.GetButtonDown(New);

        public static bool IsOption => Input.GetButtonDown(Option);

        public static bool IsPageVertical => Math.Abs(Input.GetAxis(PageVertical)) > Tolerance;
        public static bool IsPageDown => Input.GetAxis(PageVertical) < 0;
        public static bool IsPageUp => Input.GetAxis(PageVertical) < 0;

        public static bool IsPageHorizontal => Math.Abs(Input.GetAxis(PageHorizontal)) > Tolerance;
        public static bool IsPageLeft => Input.GetAxis(PageHorizontal) < 0;
        public static bool IsPageRight => Input.GetAxis(PageHorizontal) > 0;

        public static bool IsSave => Input.GetButtonDown(Save);

        public static bool IsSort => Input.GetButtonDown(Sort);

        public static bool IsSubmit => Input.GetKeyDown(BluetoothReturn) || Input.GetButtonDown(Submit);

        public static bool IsVertical => Input.GetButtonDown(Vertical) ||
                                         Math.Abs(Input.GetAxis(Vertical)) > Tolerance;

        public static bool IsDown => Input.GetAxis(Vertical) < 0;
        public static bool IsUp => Input.GetAxis(Vertical) < 0;

        // WasDirection set in CardGameManager.LateUpdate()
        public static bool WasFocusBack { get; set; }
        public static bool WasFocusNext { get; set; }
        public static bool WasDown { get; set; }
        public static bool WasUp { get; set; }
        public static bool WasLeft { get; set; }
        public static bool WasRight { get; set; }
        public static bool WasPageVertical { get; set; }
        public static bool WasPageUp { get; set; }
        public static bool WasPageDown { get; set; }
        public static bool WasPageHorizontal { get; set; }
        public static bool WasPageLeft { get; set; }
        public static bool WasPageRight { get; set; }

        public static char FilterFocusInput(char charToValidate)
        {
            if (charToValidate == '`')
                charToValidate = '\0';
            return charToValidate;
        }
    }
}
