using System.Text;
using SharpGits.Console.GitObjects;

namespace SharpGits.Console.Data;

public class BlobSerializer
{
    public byte[] Serialize(Blob blob)
    {
	    var blobContent = blob.Content;
	    var blobPrefix = Encoding.ASCII.GetBytes("blob " + blobContent.Length + "\0");

        return CombineByteArrays(blobPrefix, blobContent);
    }

    public Blob Deserialize(byte[] blobBytes)
    {
        throw new NotImplementedException();
    }

    private static byte[] CombineByteArrays(byte[] array1, byte[] array2)
    {
	    var array1Length = array1.Length;
	    var array2Length = array2.Length;

	    var combinedByteArray = new byte[array1Length + array2Length];
	    Buffer.BlockCopy(array1, 0, combinedByteArray, 0, array1Length);
	    Buffer.BlockCopy(array2, 0, combinedByteArray, array1Length, array2Length);

	    return combinedByteArray;
    }
}