﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace xamarin_login_app
{
    public class MaxLengthCheckValidator : Behavior<Entry>
    {
        public int MaxLength { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            // if Entry text is longer then valid length
            if (entry.Text.Length > this.MaxLength)
            {
                string entryText = entry.Text;

                entryText = entryText.Remove(entryText.Length - 1); // remove last char
                                                                    //entryText = entryText.Remove(MaxLength - 1, entryText.Length);

                entry.Text = entryText;
            }
        }
    }
}
