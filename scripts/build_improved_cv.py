from pathlib import Path

from PIL import Image, ImageDraw
from reportlab.lib import colors
from reportlab.lib.pagesizes import A4
from reportlab.lib.styles import ParagraphStyle
from reportlab.lib.units import mm
from reportlab.pdfbase.pdfmetrics import stringWidth
from reportlab.platypus import Paragraph
from reportlab.pdfgen import canvas

ROOT = Path(__file__).resolve().parents[1]
OUT_DIR = ROOT / "output" / "pdf"
TMP_DIR = ROOT / "tmp" / "pdfs" / "cv-photo"
SOURCE_PAGE = TMP_DIR / "source-page-1.png"
PHOTO = TMP_DIR / "orestis-photo.png"
OUTPUT = OUT_DIR / "Orestis_Ioannis_Soultatis_CV_Improved.pdf"


def crop_photo() -> None:
    img = Image.open(SOURCE_PAGE).convert("RGBA")
    w, h = img.size
    crop = img.crop((int(w * 0.072), int(h * 0.038), int(w * 0.292), int(h * 0.195)))
    size = min(crop.size)
    left = (crop.width - size) // 2
    top = (crop.height - size) // 2
    crop = crop.crop((left, top, left + size, top + size)).resize((680, 680), Image.LANCZOS)

    mask = Image.new("L", crop.size, 0)
    draw = ImageDraw.Draw(mask)
    draw.ellipse((0, 0, crop.size[0] - 1, crop.size[1] - 1), fill=255)
    out = Image.new("RGBA", crop.size, (255, 255, 255, 0))
    out.paste(crop, (0, 0), mask)
    PHOTO.parent.mkdir(parents=True, exist_ok=True)
    out.save(PHOTO)


def draw_paragraph(c, text, x, y, width, style):
    para = Paragraph(text, style)
    _, height = para.wrap(width, 1000)
    para.drawOn(c, x, y - height)
    return y - height


def fit_line(c, text, font, size, x, y, max_width, color, gap=5):
    c.setFillColor(color)
    c.setFont(font, size)
    if stringWidth(text, font, size) <= max_width:
        c.drawString(x, y, text)
        return y - size - gap
    words = text.split()
    line = ""
    for word in words:
        candidate = word if not line else f"{line} {word}"
        if stringWidth(candidate, font, size) <= max_width:
            line = candidate
        else:
            c.drawString(x, y, line)
            y -= size + 3
            line = word
    if line:
        c.drawString(x, y, line)
        y -= size + gap
    return y


def sidebar_section(c, title, lines, x, y, width, white, rule):
    c.setFillColor(white)
    c.setFont("Helvetica-Bold", 14.5)
    c.drawString(x, y, title)
    c.setStrokeColor(rule)
    c.setLineWidth(0.65)
    c.line(x, y - 4, x + width, y - 4)
    y -= 15
    for line in lines:
        y = fit_line(c, line, "Helvetica", 8.2, x, y, width, white, gap=4.4)
    return y - 13


def section_title(c, title, x, y, width, ink):
    c.setFillColor(ink)
    c.setFont("Helvetica-Bold", 14.5)
    c.drawString(x, y, title)
    c.setStrokeColor(ink)
    c.setLineWidth(0.75)
    c.line(x, y - 5, x + width, y - 5)
    return y - 26


def project_block(c, title, meta, body_text, x, y, width, ink, muted, body):
    meta_style = ParagraphStyle("meta", fontName="Helvetica", fontSize=8.6, leading=11.8, textColor=muted)
    body_style = ParagraphStyle("projectBody", fontName="Helvetica", fontSize=8.85, leading=13.2, textColor=body)

    c.setFillColor(ink)
    c.setFont("Helvetica-Bold", 10.7)
    c.drawString(x, y, title)
    y -= 12
    y = draw_paragraph(c, meta, x, y, width, meta_style) - 3.5
    y = draw_paragraph(c, body_text, x, y, width, body_style)
    return y - 20


def experience_block(c, title, meta, body_text, x, y, width, ink, muted, body, gap=12):
    meta_style = ParagraphStyle("expMeta", fontName="Helvetica", fontSize=8.6, leading=11.5, textColor=muted)
    body_style = ParagraphStyle("expBody", fontName="Helvetica", fontSize=8.65, leading=12.7, textColor=body)

    c.setFillColor(ink)
    c.setFont("Helvetica-Bold", 10.6)
    c.drawString(x, y, title)
    y -= 12
    y = draw_paragraph(c, meta, x, y, width, meta_style) - 3
    y = draw_paragraph(c, body_text, x, y, width, body_style)
    return y - (gap + 5)


def build_pdf() -> None:
    OUT_DIR.mkdir(parents=True, exist_ok=True)
    c = canvas.Canvas(str(OUTPUT), pagesize=A4)
    width, height = A4

    navy = colors.HexColor("#30394A")
    ink = colors.HexColor("#303847")
    body = colors.HexColor("#555B64")
    muted = colors.HexColor("#737780")
    white = colors.white
    rule = colors.HexColor("#CDD4DD")

    sidebar_w = 57 * mm
    sidebar_x = 10.5 * mm
    sidebar_text_w = sidebar_w - 19 * mm
    main_x = sidebar_w + 14 * mm
    main_w = width - main_x - 15 * mm

    c.setFillColor(navy)
    c.rect(0, 0, sidebar_w, height, fill=1, stroke=0)

    photo_size = 34 * mm
    c.drawImage(str(PHOTO), (sidebar_w - photo_size) / 2, height - 48 * mm, photo_size, photo_size, mask="auto")

    y = height - 60 * mm
    for title, lines in [
        ("Contact", ["+30 6982389981", "soultatisore@gmail.com", "linkedin.com/in/", "orestisioannissoultatis", "github.com/00r3e"]),
        ("Skills", ["C#", "ASP.NET Core", "Entity Framework", "SQL Server", "Angular", "TypeScript", "HTML / CSS", "REST APIs", "Git / GitHub", "Visual Studio", "Visual Studio Code"]),
        ("Education", ["Computer Science and", "Computer Engineering", "ATEI Thessaloniki", "2007 - 2011", "Discontinued"]),
        ("Languages", ["Greek", "English"]),
    ]:
        y = sidebar_section(c, title, lines, sidebar_x, y, sidebar_text_w, white, rule)

    c.setFillColor(ink)
    c.setFont("Helvetica-Bold", 21.5)
    c.drawString(main_x, height - 26 * mm, "Orestis Ioannis Soultatis")
    c.setFont("Helvetica", 12.6)
    c.drawString(main_x, height - 36 * mm, "Software Engineer")

    summary_style = ParagraphStyle("summary", fontName="Helvetica", fontSize=8.9, leading=13.3, textColor=body)
    y = height - 43 * mm
    summary = (
        "Software Engineer focused on .NET applications for industrial automation, machine vision, "
        "quality-control systems, and production reporting. Experienced with C#, ASP.NET Core, WPF, "
        "Windows Forms, SQL Server, Angular, TypeScript, REST APIs, SQL databases, and PLC-connected workflows."
    )
    y = draw_paragraph(c, summary, main_x, y, main_w, summary_style) - 18

    y -= 8
    y = section_title(c, 'Freelance Software Developer', main_x, y, main_w, ink)
    c.setFillColor(muted)
    c.setFont("Helvetica", 8.7)
    c.drawString(main_x, y + 5, "Selected industrial software projects | 2023 - Present")
    y -= 16

    y = project_block(
        c,
        "Industrial Barcode Inspection & Reporting System",
        "C# WPF | Cognex SDK | ASP.NET Core Web API | Angular | SQL Server",
        "Built a panel-PC application connected to a Cognex camera to read barcodes, track pass/fail inspections, store failed images, and expose production data through an API and Angular dashboard.",
        main_x,
        y,
        main_w,
        ink,
        muted,
        body,
    )

    y = project_block(
        c,
        "Medical Product Tensile Test & Reporting System",
        "C# Windows Forms | Siemens PLC | SQL Server | Printable QC reports",
        "Integrated a Windows Forms application with a Siemens PLC, compared measurements against SQL reference tables, and generated printable QC forms.",
        main_x,
        y,
        main_w,
        ink,
        muted,
        body,
    )

    y = project_block(
        c,
        "Vision-Based Pattern Inspection System",
        "C#/.NET | Machine vision | Pattern learning | SQL Server reporting",
        "Created a production-line inspection application for yogurt cups, using live reference images for pattern learning and pass/fail reporting by time period.",
        main_x,
        y,
        main_w,
        ink,
        muted,
        body,
    )

    y -= 9
    y = section_title(c, 'Professional Experience', main_x, y, main_w, ink)
    y = experience_block(
        c,
        "Software Engineer",
        "Robovision | Thessaloniki, Greece | 2021 - 2023",
        "Building Machine Vision applications for Industrial Automation, from feasibility assessment to production deployment. Designing, developing, and supporting vision-based systems in industrial environments. Creating custom in-house productivity solutions.",
        main_x,
        y,
        main_w,
        ink,
        muted,
        body,
        gap=12,
    )

    y = experience_block(
        c,
        "Audio Engineer / Sound Technician",
        "KEX Hostel, Reykjavik | 2023 - 2025   -   SuperSound, Thessaloniki | 2015 - 2020",
        "Managed technical setup, troubleshooting, and live/studio audio operations.",
        main_x,
        y,
        main_w,
        ink,
        muted,
        body,
        gap=12,
    )

    y -= 8
    y = section_title(c, 'Professional Development', main_x, y, main_w, ink)
    dev_style = ParagraphStyle("dev", fontName="Helvetica", fontSize=8.35, leading=12.2, textColor=body)
    draw_paragraph(
        c,
        "ASP.NET Core 10 (.NET 10) | True Ultimate Guide - Web Academy by Harsha Vardhan, Udemy | 2025<br/>"
        "Complete Angular 21 - Ultimate Guide - Web Academy by Harsha Vardhan, Udemy | 2025",
        main_x,
        y,
        main_w,
        dev_style,
    )

    c.showPage()
    c.save()


if __name__ == "__main__":
    crop_photo()
    build_pdf()
    print(OUTPUT)
