function HtmlEncode(text)
{
    return text.replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;')
}

function FormatText(text)
{
    return HtmlEncode(text).replace(/\n/g, '<br />');
}
function GetLogicalText(count, textToUse)
{
    if (count > 1)
        return String.format("+{0} {1}s", count, textToUse);
    else if (count < -1)
        return String.format("{0} {1}s", count, textToUse);
    else if (count == 0)
        return String.format("0 {0}s", textToUse);
    else 
        return String.format("+1 {0}", textToUse);
}