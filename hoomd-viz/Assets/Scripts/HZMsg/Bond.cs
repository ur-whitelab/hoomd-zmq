// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HZMsg
{

using global::System;
using global::FlatBuffers;

public struct Bond : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Bond __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int A { get { return __p.bb.GetInt(__p.bb_pos + 0); } }
  public void MutateA(int a) { __p.bb.PutInt(__p.bb_pos + 0, a); }
  public int B { get { return __p.bb.GetInt(__p.bb_pos + 4); } }
  public void MutateB(int b) { __p.bb.PutInt(__p.bb_pos + 4, b); }
  public int T { get { return __p.bb.GetInt(__p.bb_pos + 8); } }
  public void MutateT(int T) { __p.bb.PutInt(__p.bb_pos + 8, T); }

  public static Offset<Bond> CreateBond(FlatBufferBuilder builder, int A, int B, int T) {
    builder.Prep(4, 12);
    builder.PutInt(T);
    builder.PutInt(B);
    builder.PutInt(A);
    return new Offset<Bond>(builder.Offset);
  }
};


}
