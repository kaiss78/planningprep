function HtmlEncode(text)
{
    return text.replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;')
}

function FormatText(text)
{
    return HtmlEncode(text).replace(/\n/g, '<br />');
}