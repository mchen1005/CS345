//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Autodesk.Fbx {

public class FbxSystemUnit : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal FbxSystemUnit(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxSystemUnit obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FbxSystemUnit() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NativeMethods.delete_FbxSystemUnit(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public class ConversionOptions : global::System.IDisposable {
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;
  
    internal ConversionOptions(global::System.IntPtr cPtr, bool cMemoryOwn) {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }
  
    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ConversionOptions obj) {
      return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
  
    ~ConversionOptions() {
      Dispose();
    }
  
    public virtual void Dispose() {
      lock(this) {
        if (swigCPtr.Handle != global::System.IntPtr.Zero) {
          if (swigCMemOwn) {
            swigCMemOwn = false;
            NativeMethods.delete_FbxSystemUnit_ConversionOptions(swigCPtr);
          }
          swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        }
        global::System.GC.SuppressFinalize(this);
      }
    }
  
    public ConversionOptions() : this(NativeMethods.new_FbxSystemUnit_ConversionOptions(), true) {
    }
  
  }

  public FbxSystemUnit(double pScaleFactor, double pMultiplier) : this(NativeMethods.new_FbxSystemUnit__SWIG_0(pScaleFactor, pMultiplier), true) {
  }

  public FbxSystemUnit(double pScaleFactor) : this(NativeMethods.new_FbxSystemUnit__SWIG_1(pScaleFactor), true) {
  }

  public static FbxSystemUnit mm {
    get {
      FbxSystemUnit ret = new FbxSystemUnit(NativeMethods.FbxSystemUnit_mm_get(), false);
      return ret;
    } 
  }

  public static FbxSystemUnit dm {
    get {
      FbxSystemUnit ret = new FbxSystemUnit(NativeMethods.FbxSystemUnit_dm_get(), false);
      return ret;
    } 
  }

  public static FbxSystemUnit cm {
    get {
      FbxSystemUnit ret = new FbxSystemUnit(NativeMethods.FbxSystemUnit_cm_get(), false);
      return ret;
    } 
  }

  public static FbxSystemUnit m {
    get {
      FbxSystemUnit ret = new FbxSystemUnit(NativeMethods.FbxSystemUnit_m_get(), false);
      return ret;
    } 
  }

  public static FbxSystemUnit km {
    get {
      FbxSystemUnit ret = new FbxSystemUnit(NativeMethods.FbxSystemUnit_km_get(), false);
      return ret;
    } 
  }

  public static FbxSystemUnit Inch {
    get {
      FbxSystemUnit ret = new FbxSystemUnit(NativeMethods.FbxSystemUnit_Inch_get(), false);
      return ret;
    } 
  }

  public static FbxSystemUnit Foot {
    get {
      FbxSystemUnit ret = new FbxSystemUnit(NativeMethods.FbxSystemUnit_Foot_get(), false);
      return ret;
    } 
  }

  public static FbxSystemUnit Yard {
    get {
      FbxSystemUnit ret = new FbxSystemUnit(NativeMethods.FbxSystemUnit_Yard_get(), false);
      return ret;
    } 
  }

  public void ConvertScene(FbxScene pScene, FbxSystemUnit.ConversionOptions pOptions) {
    NativeMethods.FbxSystemUnit_ConvertScene__SWIG_0(swigCPtr, FbxScene.getCPtr(pScene), FbxSystemUnit.ConversionOptions.getCPtr(pOptions));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public void ConvertScene(FbxScene pScene) {
    NativeMethods.FbxSystemUnit_ConvertScene__SWIG_1(swigCPtr, FbxScene.getCPtr(pScene));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public double GetScaleFactor() {
    double ret = NativeMethods.FbxSystemUnit_GetScaleFactor(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetScaleFactorAsString(bool pAbbreviated) {
    string ret = NativeMethods.FbxSystemUnit_GetScaleFactorAsString__SWIG_0(swigCPtr, pAbbreviated);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetScaleFactorAsString() {
    string ret = NativeMethods.FbxSystemUnit_GetScaleFactorAsString__SWIG_1(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public double GetMultiplier() {
    double ret = NativeMethods.FbxSystemUnit_GetMultiplier(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private bool _equals(FbxSystemUnit pOther) {
    bool ret = NativeMethods.FbxSystemUnit__equals(swigCPtr, FbxSystemUnit.getCPtr(pOther));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public double GetConversionFactorTo(FbxSystemUnit pTarget) {
    double ret = NativeMethods.FbxSystemUnit_GetConversionFactorTo(swigCPtr, FbxSystemUnit.getCPtr(pTarget));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public double GetConversionFactorFrom(FbxSystemUnit pSource) {
    double ret = NativeMethods.FbxSystemUnit_GetConversionFactorFrom(swigCPtr, FbxSystemUnit.getCPtr(pSource));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool Equals(FbxSystemUnit other) {
    if (object.ReferenceEquals(other, null)) { return false; }
    return _equals(other);
  }

  public override bool Equals(object obj){
    if (object.ReferenceEquals(obj, null)) { return false; }
    /* is obj a subclass of this type; if so use our Equals */
    var typed = obj as FbxSystemUnit;
    if (!object.ReferenceEquals(typed, null)) {
      return this.Equals(typed);
    }
    /* are we a subclass of the other type; if so use their Equals */
    if (typeof(FbxSystemUnit).IsSubclassOf(obj.GetType())) {
      return obj.Equals(this);
    }
    /* types are unrelated; can't be a match */
    return false;
  }

  public static bool operator == (FbxSystemUnit a, FbxSystemUnit b) {
    if (object.ReferenceEquals(a, b)) { return true; }
    if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null)) { return false; }
    return a.Equals(b);
  }

  public static bool operator != (FbxSystemUnit a, FbxSystemUnit b) {
    return !(a == b);
  }

  public override int GetHashCode() {
    int ret = NativeMethods.FbxSystemUnit_GetHashCode(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public override string ToString() {
    var unitName = GetScaleFactorAsString();
    if (unitName == "custom unit") {
      unitName += string.Format(" ({0} cm)", GetScaleFactor());
    }
    var multiplier = GetMultiplier();
    if (multiplier != 1.0) {
      unitName += string.Format(" multiplier {0}", multiplier);
    }
    return unitName;
  }

}

}
