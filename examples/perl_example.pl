#!/usr/bin/env perl

use LWP::Simple qw( $ua get );

my $username = 'aa580e768465da258943e-zone-custom';
my $password = 'aa580e768465da258943e';
my $MANGOPROXY_DNS = '43.153.237.55:2334';
my $urlToGet = 'http://ip-api.com/json';

$ua->proxy('http', sprintf('http://%s:%s@%s', $username, $password, $MANGOPROXY_DNS));
my $contents = get($urlToGet);
print "Response: $contents";
