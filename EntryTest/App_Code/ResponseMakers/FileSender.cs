using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;

namespace EntryTest.ResponseMakers
{
    public static class FileSender
    {
        //public static string uploadFilesToRemoteUrl(string url, string[] files, list<int> formfields = null)
        //{
        //    string boundary = "----------------------------" + datetime.now.ticks.tostring("x");

        //    httpwebrequest request = (httpwebrequest)webrequest.create(url);
        //    request.contenttype = "multipart/form-data; boundary=" +
        //                            boundary;
        //    request.method = "post";
        //    request.keepalive = true;

        //    stream memstream = new system.io.memorystream();

        //    var boundarybytes = system.text.encoding.ascii.getbytes("\r\n--" +
        //                                                            boundary + "\r\n");
        //    var endboundarybytes = system.text.encoding.ascii.getbytes("\r\n--" +
        //                                                                boundary + "--");


        //    string formdatatemplate = "\r\n--" + boundary +
        //                                "\r\ncontent-disposition: form-data; name=\"{0}\";\r\n\r\n{1}";

        //    if (formfields != null)
        //    {
        //        foreach (string key in formfields.keys)
        //        {
        //            string formitem = string.format(formdatatemplate, key, formfields[key]);
        //            byte[] formitembytes = system.text.encoding.utf8.getbytes(formitem);
        //            memstream.write(formitembytes, 0, formitembytes.length);
        //        }
        //    }

        //    string headertemplate =
        //        "content-disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
        //        "content-type: application/octet-stream\r\n\r\n";

        //    for (int i = 0; i < files.length; i++)
        //    {
        //        memstream.write(boundarybytes, 0, boundarybytes.length);
        //        var header = string.format(headertemplate, "uplthefile", files[i]);
        //        var headerbytes = system.text.encoding.utf8.getbytes(header);

        //        memstream.write(headerbytes, 0, headerbytes.length);

        //        using (var filestream = new filestream(files[i], filemode.open, fileaccess.read))
        //        {
        //            var buffer = new byte[1024];
        //            var bytesread = 0;
        //            while ((bytesread = filestream.read(buffer, 0, buffer.length)) != 0)
        //            {
        //                memstream.write(buffer, 0, bytesread);
        //            }
        //        }
        //    }

        //    memstream.write(endboundarybytes, 0, endboundarybytes.length);
        //    request.contentlength = memstream.length;

        //    using (stream requeststream = request.getrequeststream())
        //    {
        //        memstream.position = 0;
        //        byte[] tempbuffer = new byte[memstream.length];
        //        memstream.read(tempbuffer, 0, tempbuffer.length);
        //        memstream.close();
        //        requeststream.write(tempbuffer, 0, tempbuffer.length);
        //    }

        //    using (var response = request.getresponse())
        //    {
        //        stream stream2 = response.getresponsestream();
        //        streamreader reader2 = new streamreader(stream2);
        //        return reader2.readtoend();
        //    }
        //}
    }
}