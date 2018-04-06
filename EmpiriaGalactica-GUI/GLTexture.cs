using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL4;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

namespace EmpiriaGalactica_GUI {
    public class GlTexture {
        
        #region Members

        /// <summary>
        /// The ID of this texture. 
        /// </summary>
        private int _textureId;

        #endregion

        #region Methods

        /// <summary>
        /// Used to create a texture from raw data in Alpha format.
        /// </summary>
        /// <param name="data">The raw data in Alpha format.</param>
        public GlTexture(byte[] data) {
            var pointer = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, pointer, data.Length);
            
            Init(pointer);
            Marshal.FreeHGlobal(pointer);
        }
        
        /// <summary>
        /// Used to create a texture from a bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        public GlTexture(Bitmap bitmap) {
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Alpha);

            Init(data.Scan0);
            
            bitmap.UnlockBits(data);
        }

        /// <summary>
        /// Uploads the texture to the GPU.
        /// </summary>
        /// <param name="data">The data to upload.</param>
        private void Init(IntPtr data) {
            _textureId = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, _textureId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);
            GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Alpha,
                64,
                64,
                0,
                PixelFormat.Alpha,
                PixelType.UnsignedByte,
                data
            );
        }

        /// <summary>
        /// Used to dispose the textuyre and free the GPU memory.
        /// </summary>
        public void Dispose() {
            GL.DeleteTexture(_textureId);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The ID of this texture to be used for rendering.
        /// </summary>
        public int TextureId => _textureId;

        #endregion

    }
}