
$(document).ready(function () {

    var errorMessages4Status = {
        add_success: "Property successfully added",
        add_error: "Wrong property name",
        edit_success: "Property successfully edited",
        edit_error: "Error during property edit",
        delete_success: "Property successfully deleted",
        ready: ""
    };

    function getURLParameter(name) {
        return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null;
    }

    // --------------------------------------------------------+
    // Статус текущего действия.
    function showStatus(status) {
        $("#message-box")
                .empty()
                .append(errorMessages4Status[status])
                .fadeIn("fast")
                .fadeOut(4000);
    }
    var status = getURLParameter("status");
    showStatus(status);

    // --------------------------------------------------------+
    // Удаление параметра.
    $(".delete-button").click(function () {
        var row = $(this).parent().parent();
        var propertyName = row.find('.property-name').text();


        // Удаляем DOM элемент
        row.remove();

        // Посылаем запрос на удаление объекта из базы данных.
        $.post('/PropertyEditor/Delete',
                { Name: propertyName },
                function (status) {
                    showStatus(status);
                });
    });

    // --------------------------------------------------------+
    // Добавление.
    $(".add-button").click(function () {
        setAddDialogVisibility(true);
    });

    // --------------------------------------------+
    // Форма добавления параметров.
    $("#AddForm").validate({
        focusInvalid: false,
        focusCleanup: true,
        rules: {
            "Name-Add": {
                required: true,
                minlength: 2,
                maxlength: 17
            },
            "Value-Add": {
                required: true,
                minlength: 2,
                maxlength: 17
            }
        },
        messages: {
            "Name-Add": {
                required: "Укажите название параметра!",
                minlength: "Не менее 2 символов",
                maxlength: "Не более 17 символов"
            },
            "Value-Add": {
                required: "Укажите значение параметра!",
                minlength: "Не менее 2 символов",
                maxlength: "Не более 17 символов"
            }
        }
    });

    /*$("#AddFormSumbitButton").click(function () {
    var Name = $("#Name").value(),
    Type = $("#Type").value(),
    Value = $("#Value").value();
    // Посылаем запрос на создание объекта в базе данных.
    $.post('/PropertyEditor/Add',
    {
    Name: Name,
    Type: Type,
    Value: Value
    },
    function (status) {
    setAddDialogVisibility(false);
    showStatus(status);
    });
    });*/
    function setAddDialogVisibility(isVisible) {
        if (isVisible) {
            $("#add-dialog-container").show();
        } else {
            $(".dialog-container").hide();
        }
    }
    setAddDialogVisibility(false);

    // --------------------------------------------+
    // Форма изменения параметров.
    $("#EditForm").validate({
        focusInvalid: false,
        focusCleanup: true,
        rules: {
            "Name-Edit": {
                required: true,
                minlength: 2,
                maxlength: 12
            },
            "Value-Edit": {
                required: true,
                minlength: 2,
                maxlength: 12
            }
        },
        messages: {
            "Name-Edit": {
                required: "Укажите название параметра!",
                minlength: "Не менее 2 символов",
                maxlength: "Не более 12 символов"
            },
            "Value-Edit": {
                required: "Укажите значение параметра!",
                minlength: "Не менее 2 символов",
                maxlength: "Не более 12 символов"
            }
        }
    });
    function setEditDialogVisibility(isVisible) {
        if (isVisible) {
            $("#edit-dialog-container").show();
        } else {
            $(".dialog-container").hide();
        }
    }
    // --------------------------------------------------------+
    // Изменение.
    $(".editable").click(function () {
        var row = $(this);
        var propertyName = row.find('.property-name').text();
        var propertyType = row.find('.property-type').text();
        var propertyValue = row.find('.property-value').text();

        setEditDialogVisibility(true);
        $("#Name-Edit").attr("value", propertyName);
        $("#Value-Edit").attr("value", propertyValue);
        $("#property-name-Edit").text("Edit property: \"" + propertyName + "\"");
        $("#Type-Edit [value='" + propertyType + "']").attr("selected", "selected");
    });

    // Скрываем диалог при нажатии за его пределы.
    $(".dialog-container").click(function (e) {
        if (this == e.target) {
            $(".dialog-container").hide();
        }
    });
});