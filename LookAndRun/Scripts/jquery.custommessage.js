	    $(document.body).ready(function()
	{
	    $('#show').click(function () { $.jmessage('Статус операции', 'Вы успешно выполнили операцию.', 3000); });

		$('#show_error').click(function () { $.jmessage('Статус операции', 'Возникли проблемы при выполнении операции. Обратитесь к администратору.', 0, 'jm_message_error'); });
		$('#show_success').click(function() { $.jmessage('В закладки', 'Запись была добавлена в ваши закладки.', 0, 'jm_message_success'); });
	});	
