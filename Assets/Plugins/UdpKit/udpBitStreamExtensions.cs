/*
* The MIT License (MIT)
* 
* Copyright (c) 2012-2013 Fredrik Holmstrom (fredrik.johan.holmstrom@gmail.com)
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

using UnityEngine;

namespace UdpKit {
    public static class UdpBitStreamExt {
        public static void WriteColor32RGBA (this UdpBitStream stream, Color32 value) {
            stream.WriteByte(value.r, 8);
            stream.WriteByte(value.g, 8);
			stream.WriteByte(value.b, 8);
            stream.WriteByte(value.a, 8);
        }

        public static Color32 ReadColor32RGBA (this UdpBitStream stream) {
            return new Color32(stream.ReadByte(8), stream.ReadByte(8), stream.ReadByte(8), stream.ReadByte(8));
        }

        public static void WriteColor32RGB (this UdpBitStream stream, Color32 value) {
            stream.WriteByte(value.r, 8);
            stream.WriteByte(value.g, 8);
            stream.WriteByte(value.b, 8);
        }

        public static Color32 ReadColor32RGB (this UdpBitStream stream) {
            return new Color32(stream.ReadByte(8), stream.ReadByte(8), stream.ReadByte(8), 0xFF);
        }

        public static void WriteVector2 (this UdpBitStream stream, Vector2 value) {
            stream.WriteFloat(value.x);
            stream.WriteFloat(value.y);
        }

        public static Vector2 ReadVector2 (this UdpBitStream stream) {
            return new Vector2(stream.ReadFloat(), stream.ReadFloat());
        }

        public static void WriteVector2Half (this UdpBitStream stream, Vector2 value) {
            stream.WriteHalf(value.x);
            stream.WriteHalf(value.y);
        }

        public static Vector2 ReadVector2Half (this UdpBitStream stream) {
            return new Vector2(stream.ReadHalf(), stream.ReadHalf());
        }

        public static void WriteVector3 (this UdpBitStream stream, Vector3 value) {
            stream.WriteFloat(value.x);
            stream.WriteFloat(value.y);
            stream.WriteFloat(value.z);
        }

        public static Vector3 ReadVector3 (this UdpBitStream stream) {
            return new Vector3(stream.ReadFloat(), stream.ReadFloat(), stream.ReadFloat());
        }

        public static void WriteVector3Half (this UdpBitStream stream, Vector3 value) {
            stream.WriteHalf(value.x);
            stream.WriteHalf(value.y);
            stream.WriteHalf(value.z);
        }

        public static Vector3 ReadVector3Half (this UdpBitStream stream) {
            return new Vector3(stream.ReadHalf(), stream.ReadHalf(), stream.ReadHalf());
        }

        public static void WriteColorRGB (this UdpBitStream stream, Color value) {
            stream.WriteFloat(value.r);
            stream.WriteFloat(value.g);
            stream.WriteFloat(value.b);
        }

        public static Color ReadColorRGB (this UdpBitStream stream) {
            return new Color(stream.ReadFloat(), stream.ReadFloat(), stream.ReadFloat());
        }

        public static void WriteColorRGBHalf (this UdpBitStream stream, Color value) {
            stream.WriteHalf(value.r);
            stream.WriteHalf(value.g);
            stream.WriteHalf(value.b);
        }

        public static Color ReadColorRGBHalf (this UdpBitStream stream) {
            return new Color(stream.ReadHalf(), stream.ReadHalf(), stream.ReadHalf());
        }

        public static void WriteVector4 (this UdpBitStream stream, Vector4 value) {
            stream.WriteFloat(value.x);
            stream.WriteFloat(value.y);
            stream.WriteFloat(value.z);
            stream.WriteFloat(value.w);
        }

        public static Vector4 ReadVector4 (this UdpBitStream stream) {
            return new Vector4(stream.ReadFloat(), stream.ReadFloat(), stream.ReadFloat(), stream.ReadFloat());
        }

        public static void WriteVector4Half (this UdpBitStream stream, Vector4 value) {
            stream.WriteHalf(value.x);
            stream.WriteHalf(value.y);
            stream.WriteHalf(value.z);
            stream.WriteHalf(value.w);
        }

        public static Vector4 ReadVector4Half (this UdpBitStream stream) {
            return new Vector4(stream.ReadHalf(), stream.ReadHalf(), stream.ReadHalf(), stream.ReadHalf());
        }

        public static void WriteColorRGBA (this UdpBitStream stream, Color value) {
            stream.WriteFloat(value.r);
            stream.WriteFloat(value.g);
            stream.WriteFloat(value.b);
            stream.WriteFloat(value.a);
        }

        public static Color ReadColorRGBA (this UdpBitStream stream) {
            return new Color(stream.ReadFloat(), stream.ReadFloat(), stream.ReadFloat(), stream.ReadFloat());
        }

        public static void WriteColorRGBAHalf (this UdpBitStream stream, Color value) {
            stream.WriteHalf(value.r);
            stream.WriteHalf(value.g);
            stream.WriteHalf(value.b);
            stream.WriteHalf(value.a);
        }

        public static Color ReadColorRGBAHalf (this UdpBitStream stream) {
            return new Color(stream.ReadHalf(), stream.ReadHalf(), stream.ReadHalf(), stream.ReadHalf());
        }

        public static void WriteQuaternion (this UdpBitStream stream, Quaternion value) {
            stream.WriteFloat(value.x);
            stream.WriteFloat(value.y);
            stream.WriteFloat(value.z);
            stream.WriteFloat(value.w);
        }

        public static Quaternion ReadQuaternion (this UdpBitStream stream) {
            return new Quaternion(stream.ReadFloat(), stream.ReadFloat(), stream.ReadFloat(), stream.ReadFloat());
        }

        public static void WriteQuaternionHalf (this UdpBitStream stream, Quaternion value) {
            stream.WriteHalf(value.x);
            stream.WriteHalf(value.y);
            stream.WriteHalf(value.z);
            stream.WriteHalf(value.w);
        }

        public static Quaternion ReadQuaternionHalf (this UdpBitStream stream) {
            return new Quaternion(stream.ReadHalf(), stream.ReadHalf(), stream.ReadHalf(), stream.ReadHalf());
        }

        public static void WriteTransform (this UdpBitStream stream, Transform transform) {
            UdpBitStreamExt.WriteVector3(stream, transform.position);
            UdpBitStreamExt.WriteQuaternion(stream, transform.rotation);
        }

        public static void ReadTransform (this UdpBitStream stream, Transform transform) {
            transform.position = UdpBitStreamExt.ReadVector3(stream);
            transform.rotation = UdpBitStreamExt.ReadQuaternion(stream);
        }

        public static void ReadTransform (this UdpBitStream stream, out Vector3 position, out Quaternion rotation) {
            position = UdpBitStreamExt.ReadVector3(stream);
            rotation = UdpBitStreamExt.ReadQuaternion(stream);
        }

        public static void WriteTransformHalf (this UdpBitStream stream, Transform transform) {
            UdpBitStreamExt.WriteVector3Half(stream, transform.position);
            UdpBitStreamExt.WriteQuaternionHalf(stream, transform.rotation);
        }

        public static void ReadTransformHalf (this UdpBitStream stream, Transform transform) {
            transform.position = UdpBitStreamExt.ReadVector3Half(stream);
            transform.rotation = UdpBitStreamExt.ReadQuaternionHalf(stream);
        }

        public static void ReadTransformHalf (this UdpBitStream stream, out Vector3 position, out Quaternion rotation) {
            position = UdpBitStreamExt.ReadVector3Half(stream);
            rotation = UdpBitStreamExt.ReadQuaternionHalf(stream);
        }

        public static void WriteRigidbody (this UdpBitStream stream, Rigidbody rigidbody) {
            UdpBitStreamExt.WriteVector3(stream, rigidbody.position);
            UdpBitStreamExt.WriteQuaternion(stream, rigidbody.rotation);
            UdpBitStreamExt.WriteVector3(stream, rigidbody.velocity);
            UdpBitStreamExt.WriteVector3(stream, rigidbody.angularVelocity);
        }

        public static void ReadRigidbody (this UdpBitStream stream, Rigidbody rigidbody) {
            rigidbody.position = UdpBitStreamExt.ReadVector3(stream);
            rigidbody.rotation = UdpBitStreamExt.ReadQuaternion(stream);
            rigidbody.velocity = UdpBitStreamExt.ReadVector3(stream);
            rigidbody.angularVelocity = UdpBitStreamExt.ReadVector3(stream);
        }

        public static void ReadRigidbody (this UdpBitStream stream, out Vector3 position, out Quaternion rotation, out Vector3 velocity, out Vector3 angularVelocity) {
            position = UdpBitStreamExt.ReadVector3(stream);
            rotation = UdpBitStreamExt.ReadQuaternion(stream);
            velocity = UdpBitStreamExt.ReadVector3(stream);
            angularVelocity = UdpBitStreamExt.ReadVector3(stream);
        }

        public static void WriteRigidbodyHalf (this UdpBitStream stream, Rigidbody rigidbody) {
            UdpBitStreamExt.WriteVector3Half(stream, rigidbody.position);
            UdpBitStreamExt.WriteQuaternionHalf(stream, rigidbody.rotation);
            UdpBitStreamExt.WriteVector3Half(stream, rigidbody.velocity);
            UdpBitStreamExt.WriteVector3Half(stream, rigidbody.angularVelocity);
        }

        public static void ReadRigidbodyHalf (this UdpBitStream stream, Rigidbody rigidbody) {
            rigidbody.position = UdpBitStreamExt.ReadVector3Half(stream);
            rigidbody.rotation = UdpBitStreamExt.ReadQuaternionHalf(stream);
            rigidbody.velocity = UdpBitStreamExt.ReadVector3Half(stream);
            rigidbody.angularVelocity = UdpBitStreamExt.ReadVector3Half(stream);
        }

        public static void ReadRigidbodyHalf (this UdpBitStream stream, out Vector3 position, out Quaternion rotation, out Vector3 velocity, out Vector3 angularVelocity) {
            position = UdpBitStreamExt.ReadVector3Half(stream);
            rotation = UdpBitStreamExt.ReadQuaternionHalf(stream);
            velocity = UdpBitStreamExt.ReadVector3Half(stream);
            angularVelocity = UdpBitStreamExt.ReadVector3Half(stream);
        }

        public static void WriteBounds (this UdpBitStream stream, Bounds b) {
            UdpBitStreamExt.WriteVector3(stream, b.center);
            UdpBitStreamExt.WriteVector3(stream, b.size);
        }

        public static Bounds ReadBounds (this UdpBitStream stream) {
            return new Bounds(UdpBitStreamExt.ReadVector3(stream), UdpBitStreamExt.ReadVector3(stream));
        }

        public static void WriteBoundsHalf (this UdpBitStream stream, Bounds b) {
            UdpBitStreamExt.WriteVector3Half(stream, b.center);
            UdpBitStreamExt.WriteVector3Half(stream, b.size);
        }

        public static Bounds ReadBoundsHalf (this UdpBitStream stream) {
            return new Bounds(UdpBitStreamExt.ReadVector3Half(stream), UdpBitStreamExt.ReadVector3Half(stream));
        }

        public static void WriteRect (this UdpBitStream stream, Rect rect) {
            stream.WriteFloat(rect.xMin);
            stream.WriteFloat(rect.yMin);
            stream.WriteFloat(rect.width);
            stream.WriteFloat(rect.height);
        }

        public static Rect ReadRect (this UdpBitStream stream) {
            return new Rect(
                stream.ReadFloat(),
                stream.ReadFloat(),
                stream.ReadFloat(),
                stream.ReadFloat()
            );
        }

        public static void WriteRectHalf (this UdpBitStream stream, Rect rect) {
            stream.WriteHalf(rect.xMin);
            stream.WriteHalf(rect.yMin);
            stream.WriteHalf(rect.width);
            stream.WriteHalf(rect.height);
        }

        public static Rect ReadRectHalf (this UdpBitStream stream) {
            return new Rect(
                stream.ReadHalf(),
                stream.ReadHalf(),
                stream.ReadHalf(),
                stream.ReadHalf()
            );
        }

        public static void WriteRay (this UdpBitStream stream, Ray ray) {
            UdpBitStreamExt.WriteVector3(stream, ray.origin);
            UdpBitStreamExt.WriteVector3(stream, ray.direction);
        }

        public static Ray ReadRay (this UdpBitStream stream) {
            return new Ray(
                UdpBitStreamExt.ReadVector3(stream),
                UdpBitStreamExt.ReadVector3(stream)
            );
        }

        public static void WriteRayHalf (this UdpBitStream stream, Ray ray) {
            UdpBitStreamExt.WriteVector3Half(stream, ray.origin);
            UdpBitStreamExt.WriteVector3Half(stream, ray.direction);
        }

        public static Ray ReadRayHalf (this UdpBitStream stream) {
            return new Ray(
                UdpBitStreamExt.ReadVector3Half(stream),
                UdpBitStreamExt.ReadVector3Half(stream)
            );
        }

        public static void WritePlane (this UdpBitStream stream, Plane plane) {
            UdpBitStreamExt.WriteVector3(stream, plane.normal);
            stream.WriteFloat(plane.distance);
        }

        public static Plane ReadPlane (this UdpBitStream stream) {
            return new Plane(
                UdpBitStreamExt.ReadVector3(stream),
                stream.ReadFloat()
            );
        }

        public static void WritePlaneHalf (this UdpBitStream stream, Plane plane) {
            UdpBitStreamExt.WriteVector3Half(stream, plane.normal);
            stream.WriteHalf(plane.distance);
        }

        public static Plane ReadPlaneHalf (this UdpBitStream stream) {
            return new Plane(
                UdpBitStreamExt.ReadVector3Half(stream),
                stream.ReadHalf()
            );
        }

        public static void WriteLayerMask (this UdpBitStream stream, LayerMask mask) {
            stream.WriteInt(mask.value, 32);
        }

        public static LayerMask ReadLayerMask (this UdpBitStream stream) {
            return stream.ReadInt(32);
        }

        public static void WriteMatrix4x4 (this UdpBitStream stream, ref Matrix4x4 m) {
            stream.WriteFloat(m.m00);
            stream.WriteFloat(m.m01);
            stream.WriteFloat(m.m02);
            stream.WriteFloat(m.m03);
            stream.WriteFloat(m.m10);
            stream.WriteFloat(m.m11);
            stream.WriteFloat(m.m12);
            stream.WriteFloat(m.m13);
            stream.WriteFloat(m.m20);
            stream.WriteFloat(m.m21);
            stream.WriteFloat(m.m22);
            stream.WriteFloat(m.m23);
            stream.WriteFloat(m.m30);
            stream.WriteFloat(m.m31);
            stream.WriteFloat(m.m32);
            stream.WriteFloat(m.m33);
        }

        public static Matrix4x4 ReadMatrix4x4 (this UdpBitStream stream) {
            Matrix4x4 m = default(Matrix4x4);
            m.m00 = stream.ReadFloat();
            m.m01 = stream.ReadFloat();
            m.m02 = stream.ReadFloat();
            m.m03 = stream.ReadFloat();
            m.m10 = stream.ReadFloat();
            m.m11 = stream.ReadFloat();
            m.m12 = stream.ReadFloat();
            m.m13 = stream.ReadFloat();
            m.m20 = stream.ReadFloat();
            m.m21 = stream.ReadFloat();
            m.m22 = stream.ReadFloat();
            m.m23 = stream.ReadFloat();
            m.m30 = stream.ReadFloat();
            m.m31 = stream.ReadFloat();
            m.m32 = stream.ReadFloat();
            m.m33 = stream.ReadFloat();
            return m;
        }

        public static void WriteMatrix4x4Half (this UdpBitStream stream, ref Matrix4x4 m) {
            stream.WriteHalf(m.m00);
            stream.WriteHalf(m.m01);
            stream.WriteHalf(m.m02);
            stream.WriteHalf(m.m03);
            stream.WriteHalf(m.m10);
            stream.WriteHalf(m.m11);
            stream.WriteHalf(m.m12);
            stream.WriteHalf(m.m13);
            stream.WriteHalf(m.m20);
            stream.WriteHalf(m.m21);
            stream.WriteHalf(m.m22);
            stream.WriteHalf(m.m23);
            stream.WriteHalf(m.m30);
            stream.WriteHalf(m.m31);
            stream.WriteHalf(m.m32);
            stream.WriteHalf(m.m33);
        }

        public static Matrix4x4 ReadMatrix4x4Half (this UdpBitStream stream) {
            Matrix4x4 m = default(Matrix4x4);
            m.m00 = stream.ReadHalf();
            m.m01 = stream.ReadHalf();
            m.m02 = stream.ReadHalf();
            m.m03 = stream.ReadHalf();
            m.m10 = stream.ReadHalf();
            m.m11 = stream.ReadHalf();
            m.m12 = stream.ReadHalf();
            m.m13 = stream.ReadHalf();
            m.m20 = stream.ReadHalf();
            m.m21 = stream.ReadHalf();
            m.m22 = stream.ReadHalf();
            m.m23 = stream.ReadHalf();
            m.m30 = stream.ReadHalf();
            m.m31 = stream.ReadHalf();
            m.m32 = stream.ReadHalf();
            m.m33 = stream.ReadHalf();
            return m;
        }
    }
}