using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL4;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

namespace EmpiriaGalactica_GUI.GlUtils {
    public class GlTexture {

        #region Members

        private readonly int _id;
        
        #endregion
        
        #region Methods
        
        public GlTexture(Bitmap bitmap) {
            _id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, _id);
            
            var data = bitmap.LockBits(new Rectangle(0,
                    0,
                    bitmap.Width,
                    bitmap.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            
            GL.TexImage2D(TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                bitmap.Width,
                bitmap.Height,
                0,
                PixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0);
            
            bitmap.UnlockBits (data);
            
            GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
        }
        
        #endregion
        
        #region Properties

        public int TextureId => _id;

        #endregion
        
        #region Operators
        
        #endregion
        
    }
}