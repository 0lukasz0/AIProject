BEGIN { FS="," }
	{ printf("new Item { Title = \"%s\", Category = categories.Single(g => g.Name == \"%s\"), Price = %sM, SubCategory = subCategories.Single(a => a.Name == \"%s\"), ItemArtUrl = \"\/Content\/Images\/placeholder.gif\" },\n",$2,$4,$5,$3); }
END { print "Koniec\n" }
