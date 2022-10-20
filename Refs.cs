using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

public static class Refs {
    private static readonly List<WeakReference> _refs = new List<WeakReference>();

    public static readonly BindableProperty IsWatchedProperty = BindableProperty.CreateAttached("IsWatched", typeof(bool), typeof(Refs), false, propertyChanged: OnIsWatchedChanged);

    public static bool GetIsWatched(BindableObject obj) {
        return (bool)obj.GetValue(IsWatchedProperty);
    }

    public static void SetIsWatched(BindableObject obj, bool value) {
        obj.SetValue(IsWatchedProperty, value);
    }

    private static void OnIsWatchedChanged(BindableObject bindable, object oldValue, object newValue) {
        AddRef(bindable);
    }

    public static void Print() {
        GC.GetTotalMemory(true);

        foreach (var @ref in _refs) {
            if (@ref.IsAlive) {
                var obj = @ref.Target;
                Debug.WriteLine("IsAlive: " + obj.GetType().Name);
            }
            else {
                Debug.WriteLine("IsAlive: False");
            }
        }
        Debug.WriteLine("---------------");
    }

    public async static void AddRef(object p) {
        GC.Collect();
        await Task.Delay(1000);
        GC.Collect();
        _refs.Add(new WeakReference(p));
        Print();
    }
}