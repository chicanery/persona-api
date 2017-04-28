// Office UI Fabric

// Buttons
var ButtonElements = document.querySelectorAll(".ms-Button");
for (var i = 0; i < ButtonElements.length; i++) {
    new fabric['Button'](ButtonElements[i]);
}

// Command buttons
var CommandButtonElements = document.querySelectorAll(".ms-CommandButton");
for (var i = 0; i < CommandButtonElements.length; i++) {
    new fabric['CommandButton'](CommandButtonElements[i]);
}

// Command bars
var CommandBarElements = document.querySelectorAll(".ms-CommandBar");
for (var i = 0; i < CommandBarElements.length; i++) {
    new fabric['CommandBar'](CommandBarElements[i]);
}

// Text fields
var TextFieldElements = document.querySelectorAll(".ms-TextField");
for (var i = 0; i < TextFieldElements.length; i++) {
    new fabric['TextField'](TextFieldElements[i]);
}


// Check boxes
var CheckBoxElements = document.querySelectorAll(".ms-CheckBox");
for (var i = 0; i < CheckBoxElements.length; i++) {
    new fabric['CheckBox'](CheckBoxElements[i]);
}
