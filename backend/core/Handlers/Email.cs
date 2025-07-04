using System;
using System.Net;
using System.Net.Mail;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.IO;


namespace core.Handlers
{
	public class Email
	{


		public static string CreatePDF()
		{
			try
			{
				PdfDocument doc = new PdfDocument();
				PdfPage page = doc.Pages.Add();

				PdfGraphics graphics = page.Graphics;

				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "images");

				var imagePath = Path.Combine(pathToSave, "logo.png");
				
				PdfBitmap image = new PdfBitmap(imagePath);

				graphics.DrawImage(image, 0, 0);

				var pathToSave2 = Path.Combine(Directory.GetCurrentDirectory(), "files");

				var Filepath = Path.Combine(pathToSave2, "Prescription.pdf");

				doc.Save("prescription.pdf");
				doc.Close();
				return "file created successfully";
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public static Models.Email_Model sendEmail(string email)
		{
			var response = new Models.Email_Model();
			response.Response = "Email Sent Successfully";
			try
			{
				using (MailMessage mail = new MailMessage())
				{
					mail.From = new MailAddress("hazembayoudh886@gmail.com");
					mail.To.Add(email);
					mail.Subject = "this is your prescription";
					

					using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
					{
						smtp.Credentials = new NetworkCredential("hazembayoudh886@gmail.com", "hazem+19");
						smtp.EnableSsl = true;
						smtp.Send(mail);

					}
				}
				return response;
			}
			catch(Exception ex)
			{
				response.Response = ex.Message;
				return response;
			}

		}
	}
}
